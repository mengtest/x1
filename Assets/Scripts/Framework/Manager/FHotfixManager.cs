using System;

namespace x1.Framework
{
    public class FHotfixManager : IManager
    {
        private static FHotfixManager m_inst;

        public static FHotfixManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new FHotfixManager ();
            return m_inst;
        }

        public void init ()
        {
        }

        public void exportLuaScript ()
        {
        }
    }
}

