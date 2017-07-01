using System;

namespace x1.Framework
{
    public class FSoundManager : IManager
    {
        private static FSoundManager m_inst;

        public static FSoundManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new FSoundManager ();
            return m_inst;
        }

        public FSoundManager ()
        {
        }

        public void init ()
        {
        }
    }
}

