using System;
using UnityEngine;

namespace x1.Framework
{
    public static class FConst
    {
        /// <summary>
        /// 运行的模式
        /// </summary>
        public static readonly bool F_IS_RELEASE = false;

        /// <summary>
        /// 是否导出脚本
        /// </summary>
        public static readonly bool F_IS_EXPORT_SCRIPTS = F_IS_RELEASE;

        /// <summary>
        /// 是否使用外部脚本
        /// </summary>
        public static readonly bool F_IS_EXTERNAL_SCRIPTS = F_IS_RELEASE;

        public static readonly string F_INTERNAL_ROOT = Application.streamingAssetsPath;
        public static readonly string F_EXTERNAL_ROOT = Application.persistentDataPath;
        public static readonly string F_INTERNAL_SCRIPT_ROOT = F_INTERNAL_ROOT + "/Scripts/lua";
        public static readonly string F_EXTERNAL_SCRIPT_ROOT = F_EXTERNAL_ROOT + "/Scripts/lua";
        public static readonly string F_INTERNAL_SCRIPT_LIST_PATH = F_INTERNAL_ROOT + "/ScriptList.txt";
        public static readonly string F_EXTERNAL_SCRIPT_LIST_PATH = F_EXTERNAL_ROOT + "/ScriptList.txt";
    }
}

