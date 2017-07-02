using System;
using UnityEngine;

namespace x1.Framework
{
    using XLua;

    public class FLuaBehaviour : MonoBehaviour
    {
#if true
        private Action luaAwake;
        private Action luaStart;
        private Action luaUpdate;
        private Action luaFixedUpdate;
        private Action luaOnDestroy;

        private LuaTable scriptEnv;
        private FLuaManager m_luaManager;
        private string m_className;

        void Awake ()
        {
            m_className = gameObject.name;
            m_luaManager = FLuaManager.getInstance ();
            LuaEnv luaEnv = m_luaManager.getEnv ();
            scriptEnv = luaEnv.NewTable ();

            LuaTable meta = luaEnv.NewTable ();
            meta.Set ("__index", luaEnv.Global);
            scriptEnv.SetMetaTable (meta);
            meta.Dispose ();

            scriptEnv.Set ("gameObject", gameObject);
            scriptEnv.Set ("transform", transform);
            scriptEnv.Set ("this", this);
//            foreach (var injection in injections)
//            {
//                scriptEnv.Set(injection.name, injection.value);
//            }

            string viewScript = Util.readText (FConst.F_SCRIPT_ROOT + "/View/" + m_className + ".lua");
            string ctrlScript = Util.readText (FConst.F_SCRIPT_ROOT + "/Ctrl/" + m_className + "Ctrl.lua");
            luaEnv.DoString (viewScript, "LuaBehaviour", scriptEnv);
            luaEnv.DoString (ctrlScript, "LuaBehaviour", scriptEnv);

            luaAwake = scriptEnv.Get<Action> ("Awake");
            luaStart = scriptEnv.Get<Action> ("Start");
            luaUpdate = scriptEnv.Get<Action> ("Update");
            luaFixedUpdate = scriptEnv.Get<Action> ("FixedUpdate");
            luaOnDestroy = scriptEnv.Get<Action> ("OnDestroy");

            if (luaAwake != null) {
                luaAwake ();
            }
        }

        // Use this for initialization
        void Start ()
        {
            if (luaStart != null) {
                luaStart ();
            }
        }

        // Update is called once per frame
        void Update ()
        {
            if (luaUpdate != null) {
                luaUpdate ();
            }
//            if (Time.time - LuaBehaviour.lastGCTime > GCInterval) {
//                luaEnv.Tick ();
//                LuaBehaviour.lastGCTime = Time.time;
//            }
        }

        void FixedUpdate ()
        {
            if (luaFixedUpdate != null) {
                luaFixedUpdate ();
            }
        }

        void OnDestroy ()
        {
            if (luaOnDestroy != null) {
                luaOnDestroy ();
            }
            luaAwake = null;
            luaOnDestroy = null;
            luaUpdate = null;
            luaStart = null;
            scriptEnv.Dispose ();
//            injections = null;
        }

#else
        private string m_className;
        private FLuaManager m_luaManager;

        void Awake ()
        {
            m_className = gameObject.name;
            m_luaManager = FLuaManager.getInstance ();

            m_luaManager.execute (m_className + ".Awake();");
        }

        void Start ()
        {
            m_luaManager.execute (m_className + ".Start();");
        }

        void Update ()
        {
            m_luaManager.execute (m_className + ".Update();");
        }

        void FixedUpdate ()
        {
            m_luaManager.execute (m_className + ".FixedUpdate();");
        }

        void OnEnable ()
        {
            m_luaManager.execute (m_className + ".OnEnable();");
        }

        void OnDisable ()
        {
            m_luaManager.execute (m_className + ".OnDisable();");
        }

        void OnDistory ()
        {
            m_luaManager.execute (m_className + ".OnDestory();");
        }
#endif
    }
}

