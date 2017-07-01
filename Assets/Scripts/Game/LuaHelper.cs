using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LuaHelper
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
            Assembly assb = Assembly.GetExecutingAssembly ();  //.GetExecutingAssembly();
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

    public static Canvas getCanvas ()
    {
        Canvas canvas = GameObject.FindObjectOfType<Canvas> ();
        if (canvas == null) {
            GameObject go = new GameObject ("Canvas");
            canvas = go.AddComponent<Canvas> ();
            var scaler = go.AddComponent<UnityEngine.UI.CanvasScaler> ();
            go.AddComponent<UnityEngine.UI.GraphicRaycaster> ();

            canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            scaler.uiScaleMode = UnityEngine.UI.CanvasScaler.ScaleMode.ScaleWithScreenSize;
            scaler.screenMatchMode = UnityEngine.UI.CanvasScaler.ScreenMatchMode.Expand;
            scaler.referenceResolution = new Vector2 (1080, 1920);
        }
        return canvas;
    }
}
