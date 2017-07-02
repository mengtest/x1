using System;
using System.Reflection;
using System.Collections.Generic;
using UnityEngine;

namespace x1.Framework
{
    public static class Util
    {
        public static UnityEngine.Object loadGameObject (string path)
        {
            return Resources.Load (path);
        }

        public static UnityEngine.GameObject createGameObject (GameObject prefab, Transform parent)
        {
            GameObject go = GameObject.Instantiate (prefab) as GameObject;
            go.name = prefab.name;
            go.transform.SetParent (parent);
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            go.transform.eulerAngles = Vector3.zero;
            return go;
        }

        public static System.Type getType (string classname)
        {
            System.Type t = null;
            try {
                Assembly assb = Assembly.GetExecutingAssembly ();
                t = assb.GetType (classname);
                if (t == null) {
                    assb = Assembly.Load ("UnityEngine");
                    t = assb.GetType (classname);
                }
                if (t == null) {
                    assb = Assembly.Load ("Assembly-CSharp-firstpass");
                    t = assb.GetType (classname);
                }

            } catch (Exception ex) {
                Debug.LogError (ex);
            }
            return t;

        }

        public static string readText (string path)
        {
            return System.IO.File.ReadAllText (path);
        }
    }
}

