using System;

namespace x1.Game
{
    public class GBattlePVE_1 : GBattlePVE
    {
        public override void init ()
        {
            base.init ();

            // 添加战斗单位
            addUnit (new GPlayerUnit ());
            for (int i = 0; i < 9; i++) {
                addUnit (new GRobotUnit ());
            }
        }
    }
}

