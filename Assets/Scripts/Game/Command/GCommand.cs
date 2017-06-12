using UnityEngine;
using System.Collections;

namespace Pomelo
{
    public class GCommand
    {
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
