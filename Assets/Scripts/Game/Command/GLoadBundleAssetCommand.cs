using UnityEngine;
using System.Collections;

namespace Pomelo
{

    public class GLoadBundleAssetCommand : GCommand
    {
        private string m_bundlePath;

        private string m_resPath;

        private AssetBundleRequest m_request;

        private GLoadBundleCommand m_loadBundle;

#region GCommand implementation

        public GLoadBundleAssetCommand (string bundleName, string resName)
        {
            m_bundlePath = bundleName;
            m_resPath = resName;
            m_request = null;
            m_loadBundle = null;
        }

        public override void enter ()
        {
            m_loadBundle = new GLoadBundleCommand (m_bundlePath);
            m_loadBundle.enter ();
        }

        public override void process ()
        {
            if (m_request != null)
                return;
            
            if (m_loadBundle.isDone ()) {
                AssetBundle assetBundle = m_loadBundle.getBundle ();
                m_request = assetBundle.LoadAssetAsync (m_resPath.ToLower ());
            }
        }

        public override void exit ()
        {
            m_loadBundle.exit ();
        }

        public override bool isDone ()
        {
            if (m_request == null)
                return false;
            
            return m_request.isDone;
        }

#endregion

        public UnityEngine.Object getAsset ()
        {
            return m_request.asset;
        }

    }

}
