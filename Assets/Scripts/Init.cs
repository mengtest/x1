using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace berry
{
    public class Init : MonoBehaviour
    {

        // Use this for initialization
        void Start ()
        {
#if true
            gameObject.AddComponent<GameManager> ();
#else
            LuaManager.Instance.init ();
            LuaManager.Instance.execute (@"
                require('AppManager.lua');
                AppManager.init();
                AppManager.startup();
            ");
#endif
        }
    }
}