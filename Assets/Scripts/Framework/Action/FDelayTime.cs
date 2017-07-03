using System;

namespace x1.Framework
{
    public class FDelayTime : FAction
    {
        private float m_delay;

        private float m_endTime;

        public FDelayTime (float delay)
        {
            m_delay = delay;
        }

        public override void start (System.Object obj)
        {
            m_endTime = UnityEngine.Time.time + m_delay;
        }

        public override bool isDone ()
        {
            return UnityEngine.Time.time >= m_endTime;
        }
    }
}

