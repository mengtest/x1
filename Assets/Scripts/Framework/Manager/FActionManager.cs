﻿using System;
using System.Collections.Generic;

namespace x1.Framework
{
    public class FActionManager : IManager
    {
        private static FActionManager m_inst;

        private List<FAction> m_actionList;

        public static FActionManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new FActionManager ();
            return m_inst;
        }

        public void init ()
        {
            m_actionList = new List<FAction> ();
        }

        public void runAction (FAction action, System.Object caller)
        {
            m_actionList.Add (action);
            action.start (caller);
        }

        public void step ()
        {
            float deltaTime = UnityEngine.Time.deltaTime;

            m_actionList.ForEach (delegate(FAction action) { // List<T>.ForEach 支持遍历过程中删除元素
                action.step (deltaTime);
                
                if (action.isDone ()) {
                    action.stop ();

                    m_actionList.Remove (action); // 删除元素
                }
            });
        }
    }
}

