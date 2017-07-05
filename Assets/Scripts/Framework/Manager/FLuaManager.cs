using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace x1.Framework
{
    public class FLuaManager : IManager
    {
        private static FLuaManager m_luaManager;
        
        private LuaEnv m_luaEnv;

        private float m_nextGCTime;

        // 十秒一次
        private const float m_luaGCInterval = 10;

        public static FLuaManager getInstance ()
        {
            if (m_luaManager == null)
                m_luaManager = new FLuaManager ();
            return m_luaManager;
        }

        public void init ()
        {
            m_luaEnv = new LuaEnv ();
            m_luaEnv.AddLoader (loadScript);
        }

        public void execute (string luaCode)
        {
            m_luaEnv.DoString (luaCode);
        }

        public LuaEnv getEnv ()
        {
            return m_luaEnv;
        }

        public void step ()
        {
            if (Time.time > m_nextGCTime) {
                m_luaEnv.Tick ();
                m_nextGCTime = Time.time + m_luaGCInterval;
            }
        }

        /// <summary>
        /// 将内部脚本导出外部存储
        /// </summary>
        public FAction exportScript ()
        {
            string fromPath = FConst.F_INTERNAL_SCRIPT_ROOT;
            string toPath = FConst.F_EXTERNAL_SCRIPT_ROOT;

            FSequence seq = new FSequence ();
#if UNITY_EDITOR
            string[] files = Util.readTextByWWW ("file:///" + FConst.F_INTERNAL_SCRIPT_LIST_PATH).Split ('\n');
#else
            string[] files = Util.readTextByWWW (FConst.F_INTERNAL_SCRIPT_LIST_PATH).Split ('\n');
#endif
            foreach (var filename in files) {
                if (string.IsNullOrEmpty (filename))
                    continue;

                seq.addAction (exportScript (fromPath + "/" + filename, toPath + "/" + filename));
            }
            seq.addAction (exportScript (FConst.F_INTERNAL_SCRIPT_LIST_PATH, FConst.F_EXTERNAL_SCRIPT_LIST_PATH));
            this.runAction (seq);
            return seq;
        }

        private FAction exportScript (string fromPath, string toPath)
        {
            FSequence seq = new FSequence ();
#if UNITY_EDITOR
            string url = "file:///" + fromPath;
#else
            string url = fromPath;
#endif
            var http = new FHttpRequest (url);
            var call = new FCallFunc (delegate() {
                WWW req = FNetworkManager.getInstance ().getRequest (url);
                string dir = Path.GetDirectoryName (toPath);
                if (Directory.Exists (dir) == false)
                    Directory.CreateDirectory (dir);

                File.WriteAllBytes (toPath, req.bytes);
                Debug.Log (string.Format ("导出script : @ {0} @", toPath));
                FNetworkManager.getInstance ().cleanRequest (url);
            });
            seq.addAction (http);
            seq.addAction (call);
            return seq;
        }

        public void importScript ()
        {
            string[] scriptList = Util.readTextByWWW ("file:///" + FConst.F_EXTERNAL_SCRIPT_LIST_PATH).Split ('\n');
            string luacode = "";
            foreach (var scriptName in scriptList) {
                if (string.IsNullOrEmpty (scriptName))
                    continue;
                
                luacode += string.Format ("require('{0}');", scriptName);
            }
            execute (luacode); // 直接加载所有lua代码
        }

        private byte[] loadScript (ref string filepath)
        {
#if UNITY_EDITOR
            string path = FConst.F_INTERNAL_SCRIPT_ROOT + "/" + filepath;
#else
            string path = FConst.F_EXTERNAL_SCRIPT_ROOT + "/" + filepath;
#endif
            Debug.Log (string.Format ("加载script : @ {0} @", path));
            return Util.readBytesByWWW ("file:///" + path);
        }
    }
}
