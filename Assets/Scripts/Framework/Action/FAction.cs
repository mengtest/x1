using System;

namespace x1.Framework
{
    public class FAction
    {
        /// <summary>
        /// 动作开始，如果你想开始执行一个动作，请使用FActionManager.runAction
        /// </summary>
        public virtual void start ()
        {
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
    }
}

