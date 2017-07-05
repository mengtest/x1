using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FTransformAction : FFiniteTimeAction
    {
        private Transform m_trans;

        public override void setTarget (System.Object obj)
        {
            base.setTarget (obj);

            if ((obj as UnityEngine.GameObject) != null) { // obj被销毁后 (obj is UnityEngine.GameObject) 会返回true,所以这里用 as
                setTransform ((obj as UnityEngine.GameObject).transform);
            } else if ((obj as UnityEngine.Component) != null) { // obj被销毁后 (obj is UnityEngine.Component) 会返回true,所以这里用 as
                setTransform ((obj as UnityEngine.Component).transform);
            } else {
                setTransform (null);
//                Debug.LogError ("无法从未知类型中获取Transform对象");
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
