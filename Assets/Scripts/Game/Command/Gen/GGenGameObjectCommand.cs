using UnityEngine;
using System.Collections;

namespace x1.Game
{
    using x1.Framework;

    public class GGenGameObjectCommand : GCommand
    {
        private Transform m_parent;

        public GGenGameObjectCommand (Transform parent)
        {
            m_parent = parent;
        }

        public override void exit ()
        {
            UnityEngine.Object prefab = FResManager.getInstance ().getRes (FResID.PREFAB);
            if (prefab == null) {
                Debug.LogError ("请先执行" + typeof (GLoadAssetCommand).FullName + "(FResID.PREFAB)");
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
