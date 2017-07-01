using System;

namespace x1.Framework
{
    public class FLoadBundle : FAction
    {
        private string m_bundlePath;

        private UnityEngine.AssetBundleCreateRequest m_request;

        public FLoadBundle (string bundlePath)
        {
            m_bundlePath = bundlePath;
            m_request = null;
        }

        public override void start ()
        {
            m_request = UnityEngine.AssetBundle.LoadFromFileAsync (m_bundlePath);
        }

        public override void stop ()
        {
            FResManager.getInstance ().setRes (FResID.ASSETBUNDLE, m_request.assetBundle);
        }

        public override bool isDone ()
        {
            return m_request.isDone;
        }
    }
}

