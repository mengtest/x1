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
            m_luaEnv.AddLoader (__loadScript);
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
        /// 将内部脚本导出到外部存储
        /// </summary>
        public void exportScript ()
        {
            if (FConst.F_IS_EXPORT_SCRIPTS) {
                string fromPath = FConst.F_INTERNAL_SCRIPT_ROOT;
                string toPath = FConst.F_EXTERNAL_SCRIPT_ROOT;

                string[] files = Util.readTextFromInternal (FConst.F_INTERNAL_SCRIPT_LIST_PATH).Split ('\n');
                foreach (var filename in files) {
                    if (string.IsNullOrEmpty (filename))
                        continue;

                    string internalPath = fromPath + "/" + filename;
                    string externalPath = toPath + "/" + filename;

                    File.WriteAllBytes (externalPath, Util.readBytesFromInternal (internalPath));
                    Debug.Log (string.Format ("导出script : @ {0} @", externalPath));
                }
                File.WriteAllBytes (FConst.F_EXTERNAL_SCRIPT_LIST_PATH, Util.readBytesFromInternal (FConst.F_INTERNAL_SCRIPT_LIST_PATH));
            }            
        }

        /// <summary>
        /// 加载所有lua文件
        /// </summary>
        public void loadAllScript ()
        {
            string[] scriptList = null;
            if (FConst.F_IS_EXTERNAL_SCRIPTS)
                scriptList = Util.readTextFromExternal (FConst.F_EXTERNAL_SCRIPT_LIST_PATH).Split ('\n');
            else
                scriptList = Util.readTextFromInternal (FConst.F_INTERNAL_SCRIPT_LIST_PATH).Split ('\n');
            
            foreach (var scriptName in scriptList) {
                if (string.IsNullOrEmpty (scriptName))
                    continue;
                
                loadScript (scriptName); // 直接加载所有lua代码
            }
        }

        /// <summary>
        /// 加载单个lua
        /// </summary>
        /// <param name="script">Script.</param>
        public void loadScript (string script)
        {
            execute (string.Format ("require ('{0}');", script));
        }

        public void execute (string luaCode)
        {
            m_luaEnv.DoString (luaCode);
        }

        /// <summary>
        /// 加载单个lua文件,此函数为xLua的回调函数
        /// </summary>
        /// <returns>The script.</returns>
        /// <param name="filepath">Filepath.</param>
        private byte[] __loadScript (ref string filepath)
        {
            if (FConst.F_IS_EXTERNAL_SCRIPTS) {
                Debug.Log (string.Format ("加载script : @ {0} @", FConst.F_EXTERNAL_SCRIPT_ROOT + "/" + filepath));
                return Util.readBytesFromExternal (FConst.F_EXTERNAL_SCRIPT_ROOT + "/" + filepath);
            } else {
                Debug.Log (string.Format ("加载script : @ {0} @", FConst.F_INTERNAL_SCRIPT_ROOT + "/" + filepath));
                return Util.readBytesFromInternal (FConst.F_INTERNAL_SCRIPT_ROOT + "/" + filepath);
            }
        }
    }
}
