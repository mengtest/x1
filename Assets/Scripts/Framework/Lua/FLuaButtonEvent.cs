using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace x1.Framework
{
    using XLua;

    [CSharpCallLua]
    [RequireComponent (typeof (Button))]
    public class FLuaButtonEvent : MonoBehaviour
    {
        private Button m_button;

        private FLuaBehaviour m_pivot;

        private LuaEnv m_luaEnv;

        private LuaTable m_buttonEvent;

        private System.Action<System.Object, System.Object> m_luaFunc;

        void Awake ()
        {
            m_pivot = gameObject.GetComponentInParent<FLuaBehaviour> ();
            m_button = gameObject.GetComponent<Button> ();
            m_luaEnv = FLuaManager.getInstance ().getEnv ();
            m_buttonEvent = m_luaEnv.Global.Get<LuaTable> ("ButtonEvent");

            m_luaFunc = m_buttonEvent.Get<System.Action<System.Object, System.Object>> ("onClick");
            m_button.onClick.AddListener (onClick);
        }

        void onClick ()
        {
            if (m_luaFunc != null)
                m_luaFunc (gameObject, m_pivot.name);
        }
    }
}
