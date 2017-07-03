using System;

namespace x1.Framework
{
    [XLua.LuaCallCSharp]
    public static class FActionPlugin
    {
        public static void runAction (this System.Object caller, FAction action)
        {
            FActionManager.getInstance ().runAction (action, caller);
        }
    }

    [XLua.LuaCallCSharp]
    public class FAction
    {
        protected System.Object m_object;

        /// <summary>
        /// 动作开始，如果你想开始执行一个动作，请使用runAction
        /// </summary>
        public virtual void start (System.Object obj)
        {
            setObject (obj);
        }

        /// <summary>
        /// 停止
        /// </summary>
        public virtual void stop ()
        {
        }

        /// <summary>
        /// 每帧调用
        /// </summary>
        /// <param name="deltaTime">Delta time.</param>
        public virtual void step (float deltaTime)
        {
        }

        /// <summary>
        /// 根据percent值更新动作中的状态
        /// </summary>
        /// <param name="percent">百分比值</param>
        public virtual void update (float percent)
        {
        }

        public virtual bool isDone ()
        {
            return false;
        }

        public virtual System.Object getObject ()
        {
            return m_object;
        }

        public virtual void setObject (System.Object obj)
        {
            m_object = obj;
        }
    }
}

