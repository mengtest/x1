﻿using UnityEngine;
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
            var canvas = LuaHelper.getCanvas ();

            // TODO: 这里应该先进行判断,因为有可能外部lua文件版本比安装包中的版本新
            FHotfixManager.getInstance ().exportLuaScript ();

            FLuaManager.getInstance ().execute (@"
                require('AppManager.lua');
                AppManager.init();
                AppManager.startup();
            ");

            FSequence seq = new FSequence ();
            seq.addAction (new FLoadAsset (FResID.PREFAB, "GUI/UILoading"));
            seq.addAction (new FLoadAsset (FResID.SPRITE, "Texture/item_04_043"));
            seq.addAction (new GGenImageCommand (canvas.transform));
            seq.addAction (new FUnloadAsset (FResID.SPRITE));
            seq.addAction (new FUnloadAsset (FResID.PREFAB));
            m_actionManager.runAction (seq);
        }
    }
}
