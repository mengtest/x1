using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FRepeatForever : FFiniteTimeAction
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
//        base.step (deltaTime);
            m_innerAction.step (deltaTime);
            if (m_innerAction.isDone ()) {
                m_innerAction.start (this.getObject ());
            }
        }
    }
}
