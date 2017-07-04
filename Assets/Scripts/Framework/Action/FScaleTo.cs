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

            Transform transform = getTransform ();
            if (transform)
                m_fromEulerAngles = transform.localScale;
        }

        public override void update (float percent)
        {
            Transform transform = getTransform ();
            if (transform)
                transform.localScale = Vector3.Lerp (m_fromEulerAngles, m_targetEulerAngles, percent);
        }
    }
}
