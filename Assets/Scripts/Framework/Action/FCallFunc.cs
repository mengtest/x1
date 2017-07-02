using System;

namespace x1.Framework
{
    public class FCallFunc : FAction
    {
        private System.Action m_callback;

        public FCallFunc (System.Action callback)
        {
            m_callback = callback;
        }

        public override void stop ()
        {
            base.stop ();

            if (m_callback != null)
                m_callback ();
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}

