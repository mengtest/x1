using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace x1.Game
{
    public class GBattleBase
    {
        private List<IBattleUnit> m_battleUnits;

        public void addUnit (IBattleUnit unit)
        {
            m_battleUnits.Add (unit);
        }

        public void remoteUnit (IBattleUnit unit)
        {
            m_battleUnits.Remove (unit);
        }

        public IBattleUnit[] getUnits ()
        {
            return m_battleUnits.ToArray ();
        }

        /// <summary>
        /// 初始化数据
        /// </summary>
        public virtual void init ()
        {
            m_battleUnits = new List<IBattleUnit> ();
        }

        /// <summary>
        /// 加载UI
        /// </summary>
        public virtual void loadUI ()
        {
        }

        /// <summary>
        /// 初始化UI
        /// </summary>
        public virtual void initUI ()
        {
        }

        /// <summary>
        /// 进入战斗
        /// </summary>
        public virtual void enter ()
        {
        }

        /// <summary>
        /// 退出战斗
        /// </summary>
        public virtual void exit ()
        {
        }

        /// <summary>
        /// 开始战斗
        /// </summary>
        public virtual void start ()
        {
        }

        /// <summary>
        /// 结束战斗
        /// </summary>
        public virtual void over ()
        {
        }

        /// <summary>
        /// 暂停战斗
        /// </summary>
        public virtual void pause ()
        {
        }

        /// <summary>
        /// 继续战斗
        /// </summary>
        public virtual void resume ()
        {
        }

        /// <summary>
        /// 战斗进程
        /// </summary>
        /// <param name="deltaTime">Delta time.</param>
        public virtual void step (float deltaTime)
        {
            foreach (IBattleUnit unit in m_battleUnits) {
                unit.step (deltaTime);
            }
        }
    }
    
}
