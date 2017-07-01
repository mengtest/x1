using UnityEngine;
using System.Collections;

namespace x1.Game
{
    using x1.Framework;

    public class GGenGameObjectCommand : FAction
    {
        private Transform m_parent;

        public GGenGameObjectCommand (Transform parent)
        {
            m_parent = parent;
        }

        public override void stop ()
        {
            UnityEngine.Object prefab = FResManager.getInstance ().getRes (FResID.PREFAB);
            if (prefab == null) {
                Debug.LogError ("请先执行" + typeof (FLoadAsset).FullName + "(FResID.PREFAB)");
                return;
            }
            GameObject.Instantiate (prefab, m_parent);
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}
