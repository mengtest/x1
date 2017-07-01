using UnityEngine;
using System.Collections;

namespace x1.Game
{
    public class GBattleManager
    {
        private static GBattleManager m_inst;

        public static GBattleManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new GBattleManager ();
            return m_inst;
        }

        public GBattleBase createBattle (int levelId)
        {
            switch (levelId) {
            case 1:
                return new GBattlePVE_1 ();
            default:
                break;
            }
            return null;
        }
    }
}
