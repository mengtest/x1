using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace x1.Framework
{
    public class FUIManager : IManager
    {
        [XLua.CSharpCallLua]
        public delegate void loaded_callback (GameObject go);

        private static FUIManager m_inst;

        private Canvas m_canvas;

        public static FUIManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new FUIManager ();
            return m_inst;
        }

        public void init ()
        {
            m_canvas = findCanvas ();
        }

        public void cleanup ()
        {
        }

        public Canvas findCanvas ()
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

        public Canvas getCanvas ()
        {
            return m_canvas;
        }

        public void pushPanel (string uiName, loaded_callback loaded)
        {
            FSequence seq = new FSequence ();
            seq.addAction (new FLoadAsset (FResID.PREFAB, "gui/" + uiName));
            seq.addAction (new FGenGameObject (m_canvas.transform));
            seq.addAction (new FUnloadAsset (FResID.PREFAB));
            seq.addAction (new FCallFunc (delegate() {
                GameObject go = FResManager.getInstance ().getRes (FResID.GAMEOBJECT) as GameObject;
                go.name = uiName;
                FLuaBehaviour luaBehaviour = go.GetComponent<FLuaBehaviour> ();
                if (luaBehaviour == null)
                    luaBehaviour = go.AddComponent<FLuaBehaviour> ();
                
                if (loaded != null)
                    loaded (go);
            }));
            this.runAction (seq);
        }

        public void popPanel ()
        {
        }

        public void pushDialog (string uiName)
        {
        }

        public void popDialog ()
        {
        }
    }
}
