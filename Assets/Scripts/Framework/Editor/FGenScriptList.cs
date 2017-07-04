﻿using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace x1.Framework
{
    public static class FGenScriptList
    {
        [MenuItem ("Framework/Generate Lua Script List")]
        public static void genScriptList ()
        {
            string scriptRoot = Application.streamingAssetsPath + "/lua";
            string[] scriptList = Directory.GetFiles (scriptRoot, "*.lua", SearchOption.AllDirectories);
            using (FileStream f = File.Open (FConst.F_SCRIPT_LIST_PATH, FileMode.Create, FileAccess.Write)) {
                using (StreamWriter w = new StreamWriter (f)) {
                    foreach (var script in scriptList) {
                        string relativePath = script.Remove (0, scriptRoot.Length + 1);
                        relativePath = relativePath.Replace ('\\', '/');
                        w.WriteLine (relativePath);
                    }
                }
            }
            AssetDatabase.Refresh ();
        }
    }
}