using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace x1.Framework
{
    using XLua;

    public class FLuaBehaviour : MonoBehaviour
    {
        private Action luaInit;
        private Action luaAwake;
        private Action luaOnEnable;
        private Action luaOnDisable;
        private Action luaStart;
        private Action luaUpdate;
        private Action luaFixedUpdate;
        private Action luaOnDestroy;

        private FLuaManager m_luaManager;
        private string m_className;

        void Awake ()
        {
            m_className = gameObject.name;
            m_luaManager = FLuaManager.getInstance ();
            LuaEnv luaEnv = m_luaManager.getEnv ();
            LuaTable viewScript = luaEnv.Global.GetInPath<LuaTable> (m_className);
            LuaTable ctrlScript = luaEnv.Global.GetInPath<LuaTable> (m_className + "Ctrl");

            viewScript.Set ("gameObject", gameObject);
            viewScript.Set ("transform", transform);

            luaInit = viewScript.Get<Action> ("init");
            luaAwake = viewScript.Get<Action> ("Awake");
            luaOnEnable = viewScript.Get<Action> ("OnEnable");
            luaOnDisable = viewScript.Get<Action> ("OnDisable");
            luaStart = viewScript.Get<Action> ("Start");
            luaUpdate = viewScript.Get<Action> ("Update");
            luaFixedUpdate = viewScript.Get<Action> ("FixedUpdate");
            luaOnDestroy = viewScript.Get<Action> ("OnDestroy");

            var btns = transform.GetComponentsInChildren<Button> (true);
            foreach (var btn in btns) {
                UnityAction onClick = ctrlScript.Get<UnityAction> (btn.name + "_onClick");
                if (onClick != null)
                    btn.onClick.AddListener (onClick);
            }
            luaInit ();
            if (luaAwake != null) {
                luaAwake ();
            }
        }

        void OnEnable ()
        {
            if (luaOnEnable != null)
                luaOnEnable ();
        }

        void OnDisable ()
        {
            if (luaOnDisable != null)
                luaOnDisable ();
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
            if (luaUpdate != null)
                luaUpdate ();
        }

        void FixedUpdate ()
        {
            if (luaFixedUpdate != null)
                luaFixedUpdate ();
        }

        void OnDestroy ()
        {
            if (luaOnDestroy != null)
                luaOnDestroy ();
            
            luaAwake = null;
            luaOnDestroy = null;
            luaUpdate = null;
            luaStart = null;
        }
    }
}

