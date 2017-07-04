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
            m_luaEnv.AddLoader (loadLua);

            string[] scriptList = File.ReadAllLines (FConst.F_SCRIPT_LIST_PATH);
            string luacode = "";
            foreach (var script in scriptList) {
                luacode += string.Format ("require('{0}');", script);
            }
            execute (luacode);
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

        private byte[] loadLua (ref string filepath)
        {
            Debug.Log ("load lua : " + filepath);
            byte[] scriptCode = null;
#if UNITY_EDITOR
            WWW w = new WWW ("file:///" + Application.streamingAssetsPath + "/Scripts/lua/" + filepath);
#else
            WWW w = new WWW (Application.streamingAssetsPath + "/Scripts/lua/" + filepath);
#endif
            while (w.isDone == false) // TODO: 手机上用其他方式读取不了 streamingAssets 目录,WWW又是异步执行,所以这里先用循环解决此问题.以后会将此目录下所有文件拷贝至 persistentDataPath 目录下
                ;
            scriptCode = w.bytes;
            w.Dispose ();
            return scriptCode;
        }

    }
}
