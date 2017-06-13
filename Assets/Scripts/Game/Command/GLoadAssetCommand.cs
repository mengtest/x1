using UnityEngine;
using System.Collections;

namespace Pomelo
{

    public class GLoadAssetCommand : GCommand
    {

        private int m_resId;

        private string m_resPath;

        private ResourceRequest m_request;

#region GCommand implementation

        public GLoadAssetCommand (int resId, string resPath)
        {
            m_resId = resId;
            m_resPath = resPath;
            m_request = null;
        }

        public override void enter ()
        {
            m_request = Resources.LoadAsync (m_resPath);
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
            return m_request.isDone;
        }

#endregion

        public UnityEngine.Object getAsset ()
        {
            return m_request.asset;
        }
        
    }

}
