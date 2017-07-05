using System;

namespace x1.Framework
{
    public class FWaitFor : FAction
    {
        private IAsync m_async;

        public FWaitFor (IAsync async)
        {
            m_async = async;
        }

        public override bool isDone ()
        {
            return m_async.isDone ();
        }
    }
}

