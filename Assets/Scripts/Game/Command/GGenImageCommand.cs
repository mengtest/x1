using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Pomelo
{

    public class GGenImageCommand : GCommand
    {
        private Transform m_parent;

        public GGenImageCommand (Transform parent)
        {
            m_parent = parent;
        }

#region GCommand implementation

        public override void enter ()
        {
        }

        public override void process ()
        {
        }

        public override void exit ()
        {
            GameObject go = new GameObject ("genTexture");
            go.transform.parent = m_parent;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
            go.transform.localScale = Vector3.one;

            Image imgCtrl = go.AddComponent<Image> ();
            Texture2D tex = m_cmdMgr.getData (GResID.TEXTURE2D) as Texture2D;
            imgCtrl.sprite = Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height), new Vector2 (0.5f, 0.5f));
            imgCtrl.SetNativeSize ();
        }

        public override bool isDone ()
        {
            return true;
        }

#endregion
    }
}
