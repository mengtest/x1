using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace x1.Framework
{
    using XLua;

    [CSharpCallLua]
    public class FLuaBehaviour : MonoBehaviour
    {
        private Action m_luaInit;
        private Action m_luaAwake;
        private Action m_luaOnEnable;
        private Action m_luaOnDisable;
        private Action m_luaStart;
        private Action m_luaUpdate;
        private Action m_luaFixedUpdate;
        private Action m_luaOnDestroy;
        private Action m_luaOnApplicationPause;
        private Action m_luaOnApplicationFocus;
        private Action m_luaOnApplicationQuit;

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

            m_luaInit = viewScript.Get<Action> ("init");
            m_luaAwake = viewScript.Get<Action> ("Awake");
            m_luaOnEnable = viewScript.Get<Action> ("OnEnable");
            m_luaOnDisable = viewScript.Get<Action> ("OnDisable");
            m_luaStart = viewScript.Get<Action> ("Start");
            m_luaUpdate = viewScript.Get<Action> ("Update");
            m_luaFixedUpdate = viewScript.Get<Action> ("FixedUpdate");
            m_luaOnDestroy = viewScript.Get<Action> ("OnDestroy");
            m_luaOnApplicationPause = viewScript.Get<Action> ("OnApplicationPause");
            m_luaOnApplicationFocus = viewScript.Get<Action> ("OnApplicationFocus");
            m_luaOnApplicationQuit = viewScript.Get<Action> ("OnApplicationQuit");

            var btns = transform.GetComponentsInChildren<Button> (true);
            foreach (var btn in btns) {
                UnityAction onClick = ctrlScript.Get<UnityAction> (btn.name + "_onClick");
                if (onClick != null)
                    btn.onClick.AddListener (onClick);
            }

            if (m_luaInit != null)
                m_luaInit ();
            
            if (m_luaAwake != null)
                m_luaAwake ();
        }

        void OnEnable ()
        {
            if (m_luaOnEnable != null)
                m_luaOnEnable ();
        }

        void OnDisable ()
        {
            if (m_luaOnDisable != null)
                m_luaOnDisable ();
        }

        // Use this for initialization
        void Start ()
        {
            if (m_luaStart != null) {
                m_luaStart ();
            }
        }

        // Update is called once per frame
        void Update ()
        {
            if (m_luaUpdate != null)
                m_luaUpdate ();
        }

        void FixedUpdate ()
        {
            if (m_luaFixedUpdate != null)
                m_luaFixedUpdate ();
        }

        void OnDestroy ()
        {
            if (m_luaOnDestroy != null)
                m_luaOnDestroy ();

            m_luaAwake = null;
            m_luaOnDestroy = null;
            m_luaUpdate = null;
            m_luaStart = null;
        }

        void OnApplicationPause ()
        {
            if (m_luaOnApplicationPause != null)
                m_luaOnApplicationPause ();
        }

        void OnApplicationFocus ()
        {
            if (m_luaOnApplicationFocus != null)
                m_luaOnApplicationFocus ();
        }

        void OnApplicationQuit ()
        {
            if (m_luaOnApplicationQuit != null)
                m_luaOnApplicationQuit ();
        }
    }
}

