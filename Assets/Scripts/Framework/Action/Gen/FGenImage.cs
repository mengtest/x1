using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace x1.Framework
{
    public class FGenImage : FAction
    {
        private Transform m_parent;

        public FGenImage (Transform parent)
        {
            m_parent = parent;
        }

        public override void stop ()
        {
            GameObject go = new GameObject ("genTexture");
            go.transform.parent = m_parent;
            go.transform.localPosition = Vector3.zero;
            go.transform.localEulerAngles = Vector3.zero;
            go.transform.localScale = Vector3.one;

            Sprite sprite = FResManager.getInstance ().getRes (FResID.SPRITE) as Sprite;
            if (sprite == null) {
                Debug.LogError ("请先执行" + typeof(FLoadAsset).FullName + "(FResID.SPRITE)");
                return;
            }
            Image imgCtrl = go.AddComponent<Image> ();
            imgCtrl.sprite = sprite;
            imgCtrl.SetNativeSize ();
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}
