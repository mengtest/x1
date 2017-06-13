using UnityEngine;
using System.Collections;

namespace Pomelo
{
    public class GCommand
    {
        protected GCommandManager m_cmdMgr;

        public void init (GCommandManager cmdMgr)
        {
            m_cmdMgr = cmdMgr;
        }

        public virtual void enter ()
        {
        }

        public virtual void process ()
        {
        }

        public virtual void exit ()
        {
        }

        public virtual bool isDone ()
        {
            return false;
        }
    }
}
