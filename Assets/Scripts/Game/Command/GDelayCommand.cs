using UnityEngine;
using System.Collections;

namespace Pomelo
{

    public class GDelayCommand : GCommand
    {
        private float m_delay;

        private float m_endTime;

#region GCommand implementation

        public GDelayCommand (float delay)
        {
            m_delay = delay;
        }

        public override void enter ()
        {
            m_endTime = Time.time + m_delay;
        }

        public override void process ()
        {
        }

        public override void exit ()
        {
        }

        public override bool isDone ()
        {
            return Time.time >= m_endTime;
        }

#endregion
    }
}
