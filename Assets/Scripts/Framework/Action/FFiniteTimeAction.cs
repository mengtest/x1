using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FFiniteTimeAction : FAction
    {
        private float m_elapsedTime;
        private float m_duration;

        public override void start (object obj)
        {
            base.start (obj);

            m_elapsedTime = 0;
        }

        public override void step (float deltaTime)
        {
            m_elapsedTime += deltaTime;
            update (m_elapsedTime / getDuration ());
        }

        public override bool isDone ()
        {
            return m_elapsedTime >= getDuration ();
        }

        public float getDuration ()
        {
            return m_duration;
        }

        public void setDuration (float duration)
        {
            m_duration = duration;
        }
    }
}
