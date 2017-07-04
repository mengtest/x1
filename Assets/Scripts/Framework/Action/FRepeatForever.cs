using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FRepeatForever : FAction
    {
        private FAction m_innerAction;

        public FRepeatForever (FAction action)
        {
            m_innerAction = action;
        }

        public override void start (System.Object obj)
        {
            base.start (obj);

            m_innerAction.start (obj);
        }

        public override bool isDone ()
        {
            return false;
        }

        public override void step (float deltaTime)
        {
            if (m_innerAction.isDone ()) {
                m_innerAction.stop ();
                m_innerAction.start (this.getTarget ());
            }
            m_innerAction.step (deltaTime);
        }
    }
}
