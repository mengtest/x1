using UnityEngine;
using System.Collections;

namespace Pomelo
{

    public class GUnloadCommand : GCommand
    {
        private int m_resId;

        public GUnloadCommand (int resId)
        {
            m_resId = resId;
        }

#region GCommand implementation

        public override void enter ()
        {
        }

        public override void process ()
        {
        }

        public override void exit ()
        {
            switch (m_resId) {
            case GResID.ASSETBUNDLE:
                {
                    AssetBundle bundle = m_cmdMgr.getData (GResID.ASSETBUNDLE) as AssetBundle;
                    bundle.Unload (false);
                }
                break;
            default:
                break;
            }
        }

        public override bool isDone ()
        {
            return true;
        }

#endregion
    }
}
