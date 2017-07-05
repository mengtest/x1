using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FRotateBy : FTransformAction
    {
        private Quaternion m_fromRotation;
        private Quaternion m_deltaRotation;
        private Quaternion m_targetRotation;

        public FRotateBy (float duration, Vector3 deltaEulerAngles)
        {
            setDuration (duration);
            initWithRotation (Quaternion.Euler (deltaEulerAngles));
        }

        public FRotateBy (float duration, Quaternion rotation)
        {
            setDuration (duration);
            initWithRotation (rotation);
        }

        private  void initWithRotation (Quaternion rotation)
        {
            m_deltaRotation = rotation;
        }

        public override void start (System.Object obj)
        {
            base.start (obj);

            Debug.Log ("开始时帧数 : " + Time.frameCount);

            Transform transform = getTransform ();
            if (transform) {
                m_fromRotation = transform.localRotation;
                m_targetRotation = m_deltaRotation * m_fromRotation;
            }
        }

        public override void stop ()
        {
            base.stop ();

            Debug.Log ("结束时帧数 : " + Time.frameCount);
        }

        public override void update (float percent)
        {
            Debug.Log ("update at frame : " + Time.frameCount);
            Transform transform = getTransform ();
            if (transform)
                transform.localRotation = Quaternion.Lerp (m_fromRotation, m_targetRotation, percent);
        }
    }
}
