using UnityEngine;
using System.Collections;

namespace x1.Game
{
    using x1.Framework;

    public class GBattleManager : IManager
    {
        private static GBattleManager m_inst;

        private GBattleBase m_currentBattle;

        public static GBattleManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new GBattleManager ();
            return m_inst;
        }

        public void init ()
        {
            
        }

        public GBattleBase createBattle (int levelId)
        {
            m_currentBattle = null;
            switch (levelId) {
            case 1:
                m_currentBattle = new GBattlePVE_1 ();
                break;
            default:
                break;
            }
            return m_currentBattle;
        }

        public GBattleBase getBattle ()
        {
            return m_currentBattle;
        }
    }
}
