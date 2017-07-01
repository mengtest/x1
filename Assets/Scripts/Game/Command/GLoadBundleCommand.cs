using UnityEngine;
using System.Collections;

namespace x1.Game
{
    using x1.Framework;

    public class GLoadBundleCommand : GCommand
    {
        private string m_bundlePath;

        private AssetBundleCreateRequest m_request;

        public GLoadBundleCommand (string bundlePath)
        {
            m_bundlePath = bundlePath;
            m_request = null;
        }

        public override void enter ()
        {
            m_request = AssetBundle.LoadFromFileAsync (m_bundlePath);
        }

        public override void exit ()
        {
            FResManager.getInstance ().setRes (FResID.ASSETBUNDLE, m_request.assetBundle);
        }

        public override void process ()
        {
        }

        public override bool isDone ()
        {
            return m_request.isDone;
        }
    }

}
