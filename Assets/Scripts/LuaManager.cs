using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class LuaManager
{
    private static LuaManager m_luaManager;

    public static LuaManager getInstance ()
    {
        if (m_luaManager == null)
            m_luaManager = new LuaManager ();
        return m_luaManager;
    }

    private LuaEnv m_luaEnv;

    public void init ()
    {
        m_luaEnv = new LuaEnv ();
        m_luaEnv.AddLoader (loadLua);
    }

    public void execute (string luaCode)
    {
        m_luaEnv.DoString (luaCode);
    }

    private byte[] loadLua (ref string filepath)
    {
        return System.IO.File.ReadAllBytes (Application.streamingAssetsPath + "/lua/" + filepath);
    }
}
