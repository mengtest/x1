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
using System.Xml;
using System.Text;
using UnityEditor;
using UnityEngine;
using System.Security.Cryptography;

namespace x1.Framework
{
    public static class AssetBundleMaker
    {
        private static string assetBundleRoot = "";

        private static BuildTarget buildTarget = BuildTarget.Android;

        private static BuildAssetBundleOptions buildOptions = BuildAssetBundleOptions.None;

        [MenuItem ("Framework/AssetBundle/Build For Android")]
        public static void BuildForAndroid ()
        {
            assetBundleRoot = "android";
            buildTarget = BuildTarget.Android;
            Build ();
        }

        [MenuItem ("Framework/AssetBundle/Build For iOS")]
        public static void BuildForIOS ()
        {
            assetBundleRoot = "ios";
            buildTarget = BuildTarget.iOS;
            Build ();
        }

        [MenuItem ("Framework/AssetBundle/Build For Windows")]
        public static void BuildForWindows ()
        {
            assetBundleRoot = "win32";
            buildTarget = BuildTarget.StandaloneWindows;
            Build ();
        }

        public static void Build ()
        {
            var sw = new Stopwatch ();
            sw.Start ();

            List<AssetBundleBuild> builds = new List<AssetBundleBuild> ();

            builds.AddRange (GetBuildList (Application.dataPath + "/Resources/"));
            builds.AddRange (GetBuildList (Application.streamingAssetsPath + "/"));

            if (Directory.Exists (assetBundleRoot) == false)
                Directory.CreateDirectory (assetBundleRoot);

            BuildPipeline.BuildAssetBundles (assetBundleRoot, builds.ToArray (), buildOptions, buildTarget);

            sw.Stop ();
            UnityEngine.Debug.Log ("打包完成, 耗时 : " + sw.ElapsedMilliseconds);
        }

        public static List<AssetBundleBuild> GetBuildList (string dir)
        {
            List<AssetBundleBuild> builds = new List<AssetBundleBuild> ();
            int prefixLen = Application.dataPath.Length - "Assets".Length;
            string[] files = Directory.GetFiles (dir, "*", SearchOption.AllDirectories);
            foreach (var filename in files) {
                if (filename.EndsWith (".meta"))
                    continue;

                string assetName = filename.Remove (0, prefixLen);
                string bundleName = Util.removeExtension (assetName);

                AssetBundleBuild abb = new AssetBundleBuild ();
                abb.assetBundleName = bundleName;
                abb.assetNames = new string[]{ assetName };
                builds.Add (abb);
            }

            return builds;
        }
    }
}
