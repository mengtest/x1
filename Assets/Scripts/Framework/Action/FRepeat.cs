using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FRepeat : FAction
    {
        private FAction m_innerAction;

        /// <summary>
        /// 已经重复的次数
        /// </summary>
        private uint m_times;

        /// <summary>
        /// 总共重复次数
        /// </summary>
        private uint m_totalTimes;

        /// <summary>
        /// Initializes a new instance of the <see cref="GRepeat"/> class.
        /// </summary>
        /// <param name="times">重复次数</param>
        /// <param name="action">需要重复播放的动画</param>
        public FRepeat (uint times, FAction action)
        {
            setTimes (times);
            m_innerAction = action;
        }

        /// <summary>
        /// 设置需要重复的次数
        /// </summary>
        /// <param name="times">Times.</param>
        public void setTimes (uint times)
        {
            m_totalTimes = times;
        }

        /// <summary>
        /// 获取需要重复的次数
        /// </summary>
        /// <returns>The times.</returns>
        public uint getTimes ()
        {
            return m_totalTimes;
        }

        public override void start (System.Object obj)
        {
            base.start (obj);

            m_innerAction.start (obj);
            m_times = 0; // 播放完才算一次
        }

        public override bool isDone ()
        {
            return (m_times == m_totalTimes);
        }

        public override void step (float deltaTime)
        {
            //        base.step (deltaTime);
            m_innerAction.step (deltaTime);
            if (m_innerAction.isDone ()) {
                m_innerAction.stop ();

                ++m_times;
                if (m_times < m_totalTimes) {
                    m_innerAction.start (this.getTarget ());
                    m_innerAction.step (deltaTime);
                } else {
                    this.stop ();
                }
            }
        }
    }
}
