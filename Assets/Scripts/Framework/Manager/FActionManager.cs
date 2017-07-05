using System;
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

        public void runAction (System.Object caller, FAction action)
        {
            m_actionList.Add (action);
            action.start (caller);
        }

        public void step ()
        {
            float deltaTime = UnityEngine.Time.deltaTime;

            m_actionList.ForEach (delegate(FAction action) { // List<T>.ForEach 支持遍历过程中删除元素
                if (action.isDone () || action.getTarget () == null) {
                    action.stop ();
                    m_actionList.Remove (action); // 删除元素
                } else {
                    action.step (deltaTime);
                }
            });
        }
    }

    [XLua.LuaCallCSharp]
    public static class FActionPlugin
    {
        public static void runAction (this System.Object caller, FAction action)
        {
            FActionManager.getInstance ().runAction (caller, action);
        }
    }

}

