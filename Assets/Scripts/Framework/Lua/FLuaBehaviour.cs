using System;
using System.Text.RegularExpressions;
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

            LuaTable viewTable = luaEnv.Global.Get<LuaTable> (m_className);
            LuaTable ctrlTable = luaEnv.Global.Get<LuaTable> (m_className + "Ctrl");

            if (viewTable == null) {
                Debug.Log ("not found " + m_className + " with in lua scripts");
                return;
            }
            if (ctrlTable == null) {
                Debug.Log ("not found " + m_className + "Ctrl with in lua scripts");
                return;
            }

            viewTable.Set ("gameObject", gameObject);
            viewTable.Set ("transform", transform);

            m_luaInit = viewTable.Get<Action> ("init");
            m_luaAwake = viewTable.Get<Action> ("Awake");
            m_luaOnEnable = viewTable.Get<Action> ("OnEnable");
            m_luaOnDisable = viewTable.Get<Action> ("OnDisable");
            m_luaStart = viewTable.Get<Action> ("Start");
            m_luaUpdate = viewTable.Get<Action> ("Update");
            m_luaFixedUpdate = viewTable.Get<Action> ("FixedUpdate");
            m_luaOnDestroy = viewTable.Get<Action> ("OnDestroy");
            m_luaOnApplicationPause = viewTable.Get<Action> ("OnApplicationPause");
            m_luaOnApplicationFocus = viewTable.Get<Action> ("OnApplicationFocus");
            m_luaOnApplicationQuit = viewTable.Get<Action> ("OnApplicationQuit");

            // 注册按钮的回调函数
            var btns = transform.GetComponentsInChildren<Button> (true);
            foreach (var btn in btns) {
                FLuaButtonEvent buttnEvent = btn.GetComponent<FLuaButtonEvent> ();
                if (buttnEvent == null)
                    buttnEvent = btn.gameObject.AddComponent<FLuaButtonEvent> ();
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

        void Start ()
        {
            if (m_luaStart != null) {
                m_luaStart ();
            }
        }

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

