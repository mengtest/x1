using UnityEngine;
using System.Collections;

namespace Pomelo
{

    public class GLoadBundleAssetCommand : GCommand
    {
        private int m_resId;

        private string m_resPath;

        private AssetBundleRequest m_request;

#region GCommand implementation

        public GLoadBundleAssetCommand (int resId, string resPath)
        {
            m_resId = resId;
            m_resPath = resPath;
            m_request = null;
        }

        public override void enter ()
        {
            AssetBundle bundle = m_cmdMgr.getData (GResID.ASSETBUNDLE) as AssetBundle;
            m_request = bundle.LoadAssetAsync (m_resPath.ToLower ());
        }

        public override void process ()
        {
        }

        public override void exit ()
        {
            m_cmdMgr.setData (m_resId, m_request.asset);
        }

        public override bool isDone ()
        {
            if (m_request == null)
                return false;
            
            return m_request.isDone;
        }

#endregion
    }

}
