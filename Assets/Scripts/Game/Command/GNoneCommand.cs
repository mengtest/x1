using UnityEngine;
using System.Collections;

namespace x1.Game
{

    public class GNoneCommand : GCommand
    {
        public override void enter ()
        {
        }

        public override void exit ()
        {
        }
        
        public override void process ()
        {
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}
