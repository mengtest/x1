using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace berry
{

    public class GGenImageCommand : GCommand
    {
        private Transform m_parent;

        public GGenImageCommand (Transform parent)
        {
            m_parent = parent;
        }

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
#if false
            Texture2D tex = FResManager.getInstance ().getRes (FResID.TEXTURE) as Texture2D;
            imgCtrl.sprite = Sprite.Create (tex, new Rect (0, 0, tex.width, tex.height), new Vector2 (0.5f, 0.5f));
#else
            imgCtrl.sprite = FResManager.getInstance ().getRes (FResID.SPRITE) as Sprite;
#endif
            imgCtrl.SetNativeSize ();
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}
