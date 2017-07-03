using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FTransformAction : FFiniteTimeAction
    {
        private Transform m_trans;

        public override void setObject (System.Object obj)
        {
            base.setObject (obj);

            if (obj is UnityEngine.GameObject) {
                setTransform ((obj as UnityEngine.GameObject).transform);
            } else if (obj is UnityEngine.Component) {
                setTransform ((obj as UnityEngine.Component).transform);
            } else {
                Debug.LogError ("无法从未知类型中获取Transform对象");
            }
        }

        public void setTransform (Transform trans)
        {
            m_trans = trans;
        }

        public Transform getTransform ()
        {
            return m_trans;
        }
    }
}
