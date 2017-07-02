using System;

namespace x1.Game
{
    public interface IHero
    {
        /// <summary>
        /// 获取指定id的皮肤
        /// </summary>
        /// <returns>The skin.</returns>
        /// <param name="skinId">Skin identifier.</param>
        string getSkinTexture (uint skinId);

        /// <summary>
        /// Q
        /// </summary>
        void skill_1 ();

        /// <summary>
        /// W
        /// </summary>
        void skill_2 ();

        /// <summary>
        /// E
        /// </summary>
        void skill_3 ();

        /// <summary>
        /// R
        /// </summary>
        void skill_4 ();
    }
}

