/// <summary>
/// 同时执行
/// </summary>

using System;
using System.Collections.Generic;

namespace x1.Framework
{
    public class FSpawn : FAction
    {
        private List<FAction> m_actionList;
        private bool m_isDone;

        public FSpawn (params FAction[] actions)
        {
            m_actionList = new List<FAction> (actions);
        }

        public void addAction (FAction action)
        {
            m_actionList.Add (action);
        }

        public override void start (object target)
        {
            base.start (target);

            m_isDone = false;

            foreach (var action in m_actionList) {
                action.start (getTarget ());
            }
        }

        public override void step (float deltaTime)
        {
            bool finished = true;
            foreach (var action in m_actionList) {
                if (action.isDone () == false) {
                    action.step (deltaTime);

                    finished = false;
                    if (action.isDone ())
                        action.stop ();
                }
            }

            m_isDone = finished;
        }

        public override bool isDone ()
        {
            return m_isDone;
        }
    }
}

