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
#if false
            ctrl.add (new GLoadBundleCommand ("C:/xampp/htdocs/android/0.0.0.1/assetbundle/assets/resources/texture/items/item_03_003_0013.png"));
            ctrl.add (new GLoadBundleAssetCommand (GResID.TEXTURE2D, "assets/resources/texture/items/item_03_003_0013.png"));
            ctrl.add (new GUnloadCommand (GResID.ASSETBUNDLE));
#else
            for (int i = 0; i < 10; i++) {
                
                ctrl.add (new GLoadAssetCommand (GResID.TEXTURE2D, "Texture/item_01_" + (i + 1).ToString ("D3")));
                ctrl.add (new GGenImageCommand (m_itemParent));
            }
#endif
            ctrl.execute ();
        }

        // Update is called once per frame
        void Update ()
        {

        }
    }
}
