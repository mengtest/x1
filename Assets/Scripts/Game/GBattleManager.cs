using UnityEngine;
using System.Collections;

namespace berry
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
                return new GBattlePVE ();
            default:
                break;
            }
            return null;
        }
    }

    public class GBattleBase
    {
        public static GBattleBase m_currentBattle;

        public GBattleBase ()
        {
            m_currentBattle = this;
        }
    }

    public class GBattlePVE : GBattleBase
    {

    }
}
