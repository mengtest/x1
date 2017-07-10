/// <summary>
/// AssetBundle 打包工具
/// 配置文件:${ROOT}/ResourceDef/ForBuild.xml
/// 导出路径:${ROOT}/assetbundle
/// </summary>
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using Mono.Xml;
using UnityEditor;
using UnityEngine;
using System.Security.Cryptography;

namespace x1.Framework
{
    public class FAssetBundleMaker : EditorWindow
    {
        private string m_absolutePath;

        private Dictionary<string, BuildTarget> m_targetDict;

        private string m_selectedTarget;

        private string m_oldVersion;
        private string m_newVersion;

        [MenuItem ("Framework/AssetBundle Maker")]
        public static void createWindow ()
        {
            var w = ScriptableObject.CreateInstance<FAssetBundleMaker> ();
            w.Show ();
        }

        void reloadData ()
        {
            m_absolutePath = Directory.GetCurrentDirectory ().Replace ('\\', '/');
            m_targetDict = new Dictionary<string, BuildTarget> ();
            m_targetDict.Add ("android", BuildTarget.Android);
            m_targetDict.Add ("ios", BuildTarget.iOS);
            m_targetDict.Add ("windows", BuildTarget.StandaloneWindows);
            m_selectedTarget = "android";
            m_oldVersion = getVersion ();
            m_newVersion = "";
        }

        void OnGUI ()
        {
            if (m_targetDict == null) // 修改代码后,之前创建的窗口会报错,这里重新初始化一下
                reloadData (); 
            
            foreach (var kv in m_targetDict) {
                string targetStr = kv.Key;
                bool state = (string.Equals (m_selectedTarget, targetStr));
                if (EditorGUILayout.Toggle (targetStr, state)) {
                    m_selectedTarget = targetStr;
                }
            }

            GUILayout.Label ("CurrentVersion : " + m_oldVersion);
            m_newVersion = GUILayout.TextField (m_newVersion);

            if (string.IsNullOrEmpty (m_newVersion) == false && string.Equals (m_oldVersion, m_newVersion) == false) {
                if (GUILayout.Button ("Build AssetBundle")) {
                    // 生成AssetBundle
                    genAssetBundle ();
                    // 生成补丁包
                    genVersionPatch ();
                    // 保存版本信息
                    saveVersion ();
                }
            }
        }

        /// <summary>
        /// 生成AssetBundle
        /// </summary>
        private void genAssetBundle ()
        {
            var sw = new Stopwatch ();
            sw.Start ();

            string oldVersionRoot = m_absolutePath + "/" + m_oldVersion + "/" + m_selectedTarget;
            string newVersionRoot = m_absolutePath + "/" + m_newVersion + "/" + m_selectedTarget;

            BuildTarget buildTarget = m_targetDict [m_selectedTarget];
            List<AssetBundleBuild> builds = new List<AssetBundleBuild> ();

            // 添加要打包到AssetBundle的所有文件
            builds.AddRange (getBuildList (Application.dataPath + "/Resources/"));

            if (Directory.Exists (oldVersionRoot))
                Util.copyDierctory (oldVersionRoot, newVersionRoot); // 直接移动到新版本的目录,这样就不会重新生成所有的AssetBundle
            else
                Directory.CreateDirectory (newVersionRoot); // 第一次生成将会生成全部的AssetBundle,时间会较长
            
            BuildPipeline.BuildAssetBundles (newVersionRoot, builds.ToArray (), BuildAssetBundleOptions.None, buildTarget);
            
            sw.Stop ();
            UnityEngine.Debug.Log ("打包完成, 耗时 : " + sw.ElapsedMilliseconds + " 毫秒");
        }

        /// <summary>
        /// 导出两个版本的差异包
        /// zip格式差异包将放在新版本目录下
        /// </summary>
        /// <param name="oldVer">旧版本.</param>
        /// <param name="newVer">新版本.</param>
        private void genVersionPatch ()
        {
            string oldManifestPath = m_absolutePath + "/" + m_oldVersion + "/" + m_selectedTarget + "/" + m_selectedTarget;
            string newManifestPath = m_absolutePath + "/" + m_newVersion + "/" + m_selectedTarget + "/" + m_selectedTarget;
            string[] oldBundleList = new string[0];
            string[] newBundleList = new string[0];
            AssetBundleManifest oldManifest = null;
            AssetBundleManifest newManifest = null;

            if (File.Exists (oldManifestPath)) {
                AssetBundle oldBundle = AssetBundle.LoadFromFile (oldManifestPath);
                oldManifest = oldBundle.LoadAsset<AssetBundleManifest> ("AssetBundleManifest");
                oldBundle.Unload (false); // 同时加载两个MainBundle会报错,所以需要先unload

                oldBundleList = oldManifest.GetAllAssetBundles ();
            }

            if (File.Exists (newManifestPath)) {
                AssetBundle newBundle = AssetBundle.LoadFromFile (newManifestPath);
                newManifest = newBundle.LoadAsset<AssetBundleManifest> ("AssetBundleManifest");
                newBundle.Unload (false); // 同时加载两个MainBundle会报错,所以需要先unload
                newBundleList = newManifest.GetAllAssetBundles ();
            }

            // 得到当前版本新增的包列表
            List<string> patchFiles = new List<string> (newBundleList.Except (oldBundleList));
            foreach (var bundleName in oldBundleList) {
                var oldHash = oldManifest.GetAssetBundleHash (bundleName);
                var newHash = newManifest.GetAssetBundleHash (bundleName);

                if (oldHash != newHash) {
                    patchFiles.Add (bundleName);
                }
            }

            patchFiles.Add (newManifestPath); // manifest必须更新

            string zipPath = m_absolutePath + "/" + m_selectedTarget + "_patch_" + m_oldVersion + "_" + m_newVersion + ".zip";
            string fileRoot = m_absolutePath + "/" + m_newVersion + "/" + m_selectedTarget;

            FZipHelper.Zip (zipPath, fileRoot, patchFiles);

            UnityEngine.Debug.Log ("导出 " + m_newVersion + " 版本与 " + m_oldVersion + " 版本的差异包成功");
        }

        /// <summary>
        /// AssetBundleBuild
        /// </summary>
        /// <returns>The build list.</returns>
        /// <param name="dir">Dir.</param>
        private List<AssetBundleBuild> getBuildList (string dir)
        {
            List<AssetBundleBuild> builds = new List<AssetBundleBuild> ();
            int prefixLen = Application.dataPath.Length - "Assets".Length;
            string[] files = Directory.GetFiles (dir, "*", SearchOption.AllDirectories);
            foreach (var filename in files) {
                if (filename.EndsWith (".meta"))
                    continue;

                string assetPath = filename.Remove (0, prefixLen);
                string assetName = Util.removeExtension (assetPath);
                string bundleName = assetName;

                AssetBundleBuild abb = new AssetBundleBuild ();
                abb.assetBundleName = bundleName;
                abb.assetNames = new string[]{ assetPath };
                builds.Add (abb);
            }

            return builds;
        }

        /// <summary>
        /// 获取当前版本
        /// </summary>
        /// <returns>The version.</returns>
        private string getVersion ()
        {
            SecurityParser sp = new SecurityParser ();
            UnityEngine.Debug.Log (FConst.F_INTERNAL_VERSION_LIST_PATH);
            sp.LoadXml (Util.readTextFromInternal (FConst.F_INTERNAL_VERSION_LIST_PATH));
            SecurityElement root = sp.ToXml ();
            SecurityElement ele = root.SearchForChildByTag ("CurrentVersion");
            return ele.Text;
        }

        /// <summary>
        /// 保存新生成的版本
        /// </summary>
        private void saveVersion ()
        {
            SecurityElement ele = new SecurityElement ("root");
            SecurityElement version = new SecurityElement ("CurrentVersion");
            version.Text = m_newVersion;
            ele.AddChild (version);
            File.WriteAllText (FConst.F_INTERNAL_VERSION_LIST_PATH, ele.ToString ());
        }
    }
}
