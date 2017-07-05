using System;

namespace x1.Framework
{
    [XLua.LuaCallCSharp]
    public class FAction
    {
        private System.Object m_target;

        /// <summary>
        /// 动作开始，如果你想开始执行一个动作，请使用runAction
        /// </summary>
        public virtual void start (System.Object target)
        {
            setTarget (target);
        }

        /// <summary>
        /// 停止
        /// </summary>
        public virtual void stop ()
        {
            setTarget (null);
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
            return true;
        }

        public virtual System.Object getTarget ()
        {
            return m_target;
        }

        public virtual void setTarget (System.Object obj)
        {
            m_target = obj;
        }
    }
}

