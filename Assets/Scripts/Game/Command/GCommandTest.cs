using UnityEngine;
using System.Collections;

namespace Pomelo
{
    public class GCommandTest : MonoBehaviour
    {
        public Transform m_itemParent;

        void OnEnable ()
        {
            GCommandManager ctrl = GCommandManager.create ();
#if true
            ctrl.add (new GLoadBundleCommand ("C:/xampp/htdocs/android/0.0.0.1/assetbundle/assets/resources/texture/items/item_03_003_0013.png"));
            ctrl.add (new GLoadBundleAssetCommand (GResID.TEXTURE2D, "assets/resources/texture/items/item_03_003_0013.png"));
            ctrl.add (new GUnloadCommand (GResID.ASSETBUNDLE));
#else
            ctrl.add (new GLoadAssetCommand (GResID.TEXTURE2D, "Texture/item_04_043"));
#endif
            ctrl.add (new GGenImageCommand (m_itemParent));
            ctrl.execute ();
        }

        // Update is called once per frame
        void Update ()
        {

        }
    }
}
