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

        public List<ICommand> m_commandList;

        void Awake ()
        {
            m_inst = this;
            m_commandList = new List<ICommand> ();
        }

        void Update ()
        {
            if (m_inited == false)
                return;

            m_actionManager.step ();
        }

        void FixedUpdate ()
        {
            processCommands ();
        }

        void processCommands ()
        {
            int cmdNum = m_commandList.Count;
            for (int i = cmdNum - 1; i >= 0; --i) { // 倒序遍历,为了支持循环过程中删除元素
                m_commandList [i].process ();
            }
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
            // TODO: 这里应该先进行判断,因为有可能外部lua文件版本比安装包中的版本新
            FHotfixManager.getInstance ().exportLuaScript ();

            FLuaManager.getInstance ().execute (@"
                require('AppManager.lua');
                AppManager.init();
                AppManager.startup();
            ");
//            GCommandSequence cmdSeq = new GCommandSequence ();
//            cmdSeq.addCommand (new GCreateBattle (1));
//            cmdSeq.addCommand (new GBattleLoadUI ());
//            cmdSeq.addCommand (new GBattleInitUI ());
//            cmdSeq.execute ();
        }
    }
}
