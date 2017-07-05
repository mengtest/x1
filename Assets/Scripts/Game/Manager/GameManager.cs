using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace x1.Game
{
    using x1.Framework;

    public class GameManager : MonoBehaviour, IManager
    {
        private static GameManager m_inst;

        private bool m_inited;

        private FActionManager m_actionManager;
        private FHotfixManager m_hotfixManager;
        private FLuaManager m_luaManager;
        private FNetworkManager m_networkManager;
        private FResManager m_resManager;
        private FSoundManager m_soundManager;
        private FUIManager m_uiManager;


        public static GameManager getInstance ()
        {
            if (m_inst == null) {
                m_inst = new GameManager ();
                m_inst.m_inited = false;
            }
            return m_inst;
        }

        void Awake ()
        {
            m_inst = this;
        }

        void Update ()
        {
            if (m_inited == false)
                return;

            m_actionManager.step ();
            m_luaManager.step ();
        }

        public void init ()
        {
            m_actionManager = FActionManager.getInstance ();
            m_hotfixManager = FHotfixManager.getInstance ();
            m_luaManager = FLuaManager.getInstance ();
            m_networkManager = FNetworkManager.getInstance ();
            m_resManager = FResManager.getInstance ();
            m_soundManager = FSoundManager.getInstance ();
            m_uiManager = FUIManager.getInstance ();

            m_actionManager.init ();
            m_hotfixManager.init ();
            m_luaManager.init ();
            m_networkManager.init ();
            m_resManager.init ();
            m_soundManager.init ();
            m_uiManager.init ();

            m_inited = true;
        }

        public void startGame ()
        {
            FSequence seq = new FSequence ();
            seq.addAction (new FCallFunc (m_luaManager.exportScript));
            seq.addAction (new FCallFunc<string> (Debug.Log, "scripts导出完成"));
            seq.addAction (new FCallFunc (m_luaManager.loadAllScript));
            seq.addAction (new FCallFunc<string> (Debug.Log, "scripts加载完成"));
            seq.addAction (new FCallFunc<string> (m_luaManager.execute,
                @"
                    AppManager.init();
                    AppManager.startup();
                "
            ));
            seq.addAction (new FCallFunc<string> (Debug.Log, "启动完成"));
            this.runAction (seq);
        }
    }
}
