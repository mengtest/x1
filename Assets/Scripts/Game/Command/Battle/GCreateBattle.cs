using UnityEngine;
using System.Collections;

namespace berry
{
    public class GCreateBattle : GCommand
    {
        private int m_levelId;

        public GCreateBattle (int levelId)
        {
            m_levelId = levelId;
        }

        public override void enter ()
        {
            GBattleManager.getInstance ().createBattle (m_levelId);
            Debug.Log ("创建战斗");
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}
