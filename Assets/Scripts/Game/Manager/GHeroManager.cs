using System;

namespace x1.Game
{
    using x1.Framework;

    public class GHeroManager : IManager
    {
        private static GHeroManager m_inst;

        public static GHeroManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new GHeroManager ();
            return m_inst;
        }

#region IManager implementation

        public void init ()
        {
        }

#endregion

        public static IHero createHero (uint heroId)
        {
            switch (heroId) {
            case 1:
                return new GHero_001 ();
            case 2:
                return new GHero_002 ();
            case 3:
                return new GHero_003 ();
            case 4:
                return new GHero_004 ();
            case 5:
                return new GHero_005 ();
            case 6:
                return new GHero_006 ();
            case 7:
                return new GHero_007 ();
            case 8:
                return new GHero_008 ();
            case 9:
                return new GHero_009 ();
            case 10:
                return new GHero_010 ();
            }
            return null;
        }
    }
}

