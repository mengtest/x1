using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class Init : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {
        LuaManager.Instance.init ();
        LuaManager.Instance.execute (@"
            require('AppManager.lua');
            AppManager.init();
            AppManager.startup();
        ");
    }
}
