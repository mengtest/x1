using UnityEngine;
using System.Collections;

namespace Pomelo
{

    public class GLoadAssetCommand : GCommand
    {
        private string m_resPath;

        private ResourceRequest m_request;

#region GCommand implementation

        public GLoadAssetCommand (string resName)
        {
            m_resPath = resName;
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
