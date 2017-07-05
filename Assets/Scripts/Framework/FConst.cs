using System;
using UnityEngine;

namespace x1.Framework
{
    public static class FConst
    {
        public static readonly string F_INTERNAL_ROOT = Application.streamingAssetsPath;
        public static readonly string F_EXTERNAL_ROOT = Application.persistentDataPath;
        public static readonly string F_INTERNAL_SCRIPT_ROOT = F_INTERNAL_ROOT + "/Scripts/lua";
        public static readonly string F_EXTERNAL_SCRIPT_ROOT = F_EXTERNAL_ROOT + "/Scripts/lua";
        public static readonly string F_INTERNAL_SCRIPT_LIST_PATH = F_INTERNAL_ROOT + "/ScriptList.txt";
        public static readonly string F_EXTERNAL_SCRIPT_LIST_PATH = F_EXTERNAL_ROOT + "/ScriptList.txt";
    }
}

