using System;

namespace x1.Game
{
    using x1.Framework;

    public class GLoadBattle : FAction
    {
        private GBattleBase m_battle;

        public GLoadBattle (GBattleBase battle)
        {
            m_battle = battle;
        }

        public override void step (float deltaTime)
        {
            
        }
    }
}

