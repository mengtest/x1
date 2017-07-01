using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FUIManager : IManager
    {
        private static FUIManager m_inst;

        public static FUIManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new FUIManager ();
            return m_inst;
        }

        public void init ()
        {
        }

        public void cleanup ()
        {
        }
    }
}
