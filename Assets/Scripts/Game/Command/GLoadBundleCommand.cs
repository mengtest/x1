using UnityEngine;
using System.Collections;

namespace Pomelo
{

    public class GLoadBundleCommand : GCommand
    {
        private string m_resPath;

        private AssetBundleCreateRequest m_request;

#region GCommand implementation

        public GLoadBundleCommand (string resName)
        {
            m_resPath = resName;
            m_request = null;
        }

        public override void enter ()
        {
            m_request = AssetBundle.LoadFromFileAsync (m_resPath);
        }

        public override void process ()
        {
        }

        public override void exit ()
        {
            m_request.assetBundle.Unload (false);
        }

        public override bool isDone ()
        {
            return m_request.isDone;
        }

#endregion

        public AssetBundle getBundle ()
        {
            return m_request.assetBundle;
        }

    }

}
