using UnityEngine;
using System.Collections;

namespace Pomelo
{

    public class GLoadBundleCommand : GCommand
    {
        private string m_bundlePath;

        private AssetBundleCreateRequest m_request;

#region GCommand implementation

        public GLoadBundleCommand (string bundlePath)
        {
            m_bundlePath = bundlePath;
            m_request = null;
        }

        public override void enter ()
        {
            m_request = AssetBundle.LoadFromFileAsync (m_bundlePath);
        }

        public override void process ()
        {
        }

        public override void exit ()
        {
            m_cmdMgr.setData (GResID.ASSETBUNDLE, m_request.assetBundle);
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
