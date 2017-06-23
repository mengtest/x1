using UnityEngine;
using System.Collections;

namespace berry
{
    public class GBattleInitUI : GCommand
    {
        public override void enter ()
        {
            Debug.Log ("初始化游戏UI");
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}
