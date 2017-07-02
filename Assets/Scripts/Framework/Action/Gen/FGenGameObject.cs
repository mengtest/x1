using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FGenGameObject : FAction
    {
        private Transform m_parent;

        public FGenGameObject (Transform parent)
        {
            m_parent = parent;
        }

        public override void stop ()
        {
            UnityEngine.Object prefab = FResManager.getInstance ().getRes (FResID.PREFAB);
            if (prefab == null) {
                Debug.LogError ("请先执行" + typeof(FLoadAsset).FullName + "(FResID.PREFAB)");
                return;
            }
            GameObject go = GameObject.Instantiate (prefab, m_parent) as GameObject;
            FResManager.getInstance ().setRes (FResID.GAMEOBJECT, go);
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}
