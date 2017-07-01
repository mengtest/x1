using System;

namespace x1.Framework
{
    public class FNetworkManager : IManager
    {
        private static FNetworkManager m_inst;

        public static FNetworkManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new FNetworkManager ();
            return m_inst;
        }

        public FNetworkManager ()
        {
        }

        public void init ()
        {
        }
    }
}

