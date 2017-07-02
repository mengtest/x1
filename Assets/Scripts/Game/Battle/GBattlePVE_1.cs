using System;

namespace x1.Game
{
    public class GBattlePVE_1 : GBattlePVE
    {
        public override void init ()
        {
            base.init ();

            for (uint i = 0; i < 10; i++) {
                IHero hero = GHeroManager.createHero (i + 1);
                GRoleUnit role = new GPlayerUnit ();
                role.setHero (hero);
                role.setSkinId (0);
                role.setRoleId (i);
                addUnit (role);                
            }
        }
    }
}

