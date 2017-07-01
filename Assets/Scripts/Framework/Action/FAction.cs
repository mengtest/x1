using System;

namespace x1.Framework
{
    public class FAction
    {
        public virtual void start ()
        {
        }

        public virtual void stop ()
        {
        }

        public virtual void step (float deltaTime)
        {
        }

        public virtual void update (float percent)
        {
        }

        public virtual bool isDone ()
        {
            return false;
        }
    }
}

