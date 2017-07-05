using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FMoveBy : FTransformAction
    {
        private Vector3 m_fromPos;
        private Vector3 m_deltaPos;
        private Vector3 m_targetPos;

        public FMoveBy (float duration, Vector3 deltaPos)
        {
            m_deltaPos = deltaPos;
            setDuration (duration);
        }

        public override void start (System.Object obj)
        {
            base.start (obj);

            Transform transform = getTransform ();
            if (transform) {
                m_fromPos = transform.localPosition;
                m_targetPos = m_fromPos + m_deltaPos;
            }
        }

        public override void update (float percent)
        {
            base.update (percent);

            Transform transform = getTransform ();
            if (transform)
                transform.localPosition = Vector3.Lerp (m_fromPos, m_targetPos, percent);
        }
    }
}
