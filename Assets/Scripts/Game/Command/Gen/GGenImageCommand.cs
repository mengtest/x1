using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace x1.Game
{
    using x1.Framework;

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
            imgCtrl.sprite = FResManager.getInstance ().getRes (FResID.SPRITE) as Sprite;
            imgCtrl.SetNativeSize ();
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}
