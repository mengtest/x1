using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FScaleTo : FTransformAction
    {
        private Vector3 m_fromEulerAngles;
        private Vector3 m_targetEulerAngles;

        public FScaleTo (float duration, Vector3 targetScale)
        {
            m_targetEulerAngles = targetScale;
            setDuration (duration);
        }

        public override void start (System.Object obj)
        {
            base.start (obj);

            m_fromEulerAngles = getTransform ().localScale;
        }

        public override void update (float percent)
        {
            getTransform ().localScale = Vector3.Lerp (m_fromEulerAngles, m_targetEulerAngles, percent);
        }
    }
}
