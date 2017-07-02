using System;

namespace x1.Game
{
    public class GRoleUnit : IBattleUnit
    {
        /// <summary>
        /// 选择的英雄
        /// </summary>
        private IHero m_hero;

        /// <summary>
        /// 选择的皮肤
        /// </summary>
        private uint m_skinId;

        /// <summary>
        /// 角色id
        /// </summary>
        private uint m_roleId;

        /// <summary>
        /// 获取英雄
        /// </summary>
        /// <returns>The hero.</returns>
        public IHero getHero ()
        {
            return m_hero;
        }

        /// <summary>
        /// 设置英雄
        /// </summary>
        public void setHero (IHero hero)
        {
            m_hero = hero;
        }

        /// <summary>
        /// 获取皮肤
        /// </summary>
        /// <returns>The skin.</returns>
        public uint getSkinId ()
        {
            return m_skinId;
        }

        /// <summary>
        /// 设置皮肤,0为默认皮肤
        /// </summary>
        public void setSkinId (uint skinId)
        {
            m_skinId = skinId;
        }

        public uint getRoleId ()
        {
            return m_roleId;
        }

        public void setRoleId (uint id)
        {
            m_roleId = id;
        }

#region IBattleUnit implementation

        public void step (float deltaTime)
        {
        }

#endregion
    }
}

