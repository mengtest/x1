using System;
using System.Collections.Generic;

namespace x1.Framework
{
    public class FSequence : FAction
    {
        private List<FAction> m_actionList;
        private FAction m_currentAction;
        private int m_currentIndex;

        public FSequence (params FAction[] actions)
        {
            m_actionList = new List<FAction> (actions);
        }

        public void addAction (FAction action)
        {
            m_actionList.Add (action);
        }

        public override void start ()
        {
            base.start ();

            m_currentIndex = -1;
            m_currentAction = null;
        }

        public override void step (float deltaTime)
        {
            if (m_currentAction == null) {
                int idx = m_currentIndex + 1;

                if (idx < m_actionList.Count) {
                    m_currentAction = m_actionList [idx];
                    m_currentAction.start ();

                    m_currentIndex = idx;
                } else {
                    stop ();
                }
            } else {
                m_currentAction.step (deltaTime);

                if (m_currentAction.isDone ()) {
                    m_currentAction.stop ();
                    m_currentAction = null;
                }
            }
        }
    }
}

