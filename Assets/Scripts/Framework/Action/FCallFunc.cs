using System;

namespace x1.Framework
{
    public class FCallFunc : FAction
    {
        private System.Delegate m_callback;

        public FCallFunc (System.Action callback)
        {
            m_callback = callback;
        }

        public override void stop ()
        {
            base.stop ();

            if (m_callback != null)
                m_callback.DynamicInvoke ();
        }

        public override bool isDone ()
        {
            return true;
        }
    }

    public class FCallFunc<T1> : FAction
    {
        private System.Delegate m_callback;

        private System.Object[] m_args;

        public FCallFunc (System.Action<T1> callback, T1 arg1)
        {
            m_callback = callback;
            m_args = new object[]{ arg1 };
        }

        public override void stop ()
        {
            base.stop ();

            if (m_callback != null)
                m_callback.DynamicInvoke (m_args);
        }

        public override bool isDone ()
        {
            return true;
        }
    }

    public class FCallFunc<T1, T2> : FAction
    {
        private System.Delegate m_callback;

        private System.Object[] m_args;

        public FCallFunc (System.Action<T1, T2> callback, T1 arg1, T2 arg2)
        {
            m_callback = callback;
            m_args = new object[]{ arg1, arg2 };
        }

        public override void stop ()
        {
            base.stop ();

            if (m_callback != null)
                m_callback.DynamicInvoke (m_args);
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}

