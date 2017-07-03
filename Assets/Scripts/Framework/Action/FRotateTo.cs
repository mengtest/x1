using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FRotateTo : FTransformAction
    {
        private Vector3 m_fromEulerAngles;
        private Vector3 m_targetEulerAngles;

        public FRotateTo (float duration, Vector3 targetEulerAngles)
        {
            m_targetEulerAngles = targetEulerAngles;
            setDuration (duration);
        }

        public override void start (System.Object obj)
        {
            base.start (obj);

            m_fromEulerAngles = getTransform ().localEulerAngles;
        }

        public override void update (float percent)
        {
            getTransform ().localEulerAngles = Vector3.Lerp (m_fromEulerAngles, m_targetEulerAngles, percent);
        }
    }
}
