using UnityEngine;
using System.Collections;

namespace x1.Framework
{
    public class FActionInstant : FFiniteTimeAction
    {
        public override void step (float deltaTime)
        {
            float updateDt = 1;
            update (updateDt);
        }

        public override void update (float percent)
        {
            // nothing...
        }
    }
}
