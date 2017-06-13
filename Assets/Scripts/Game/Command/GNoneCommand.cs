using UnityEngine;
using System.Collections;

namespace Pomelo
{

    public class GNoneCommand : GCommand
    {
#region GCommand implementation

        public override void enter ()
        {
        }

        public override void process ()
        {
        }

        public override void exit ()
        {
        }

        public override bool isDone ()
        {
            return true;
        }

#endregion
    }
}
