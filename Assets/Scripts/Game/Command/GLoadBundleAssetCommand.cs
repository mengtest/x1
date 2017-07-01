using UnityEngine;
using System.Collections;

namespace x1.Game
{
    using x1.Framework;

    public class GLoadBundleAssetCommand : GCommand
    {
        private int m_resId;

        private string m_resPath;

        private AssetBundleRequest m_request;

        public GLoadBundleAssetCommand (int resId, string resPath)
        {
            m_resId = resId;
            m_resPath = resPath;
            m_request = null;
        }

        public override void enter ()
        {
            AssetBundle bundle = FResManager.getInstance ().getRes (FResID.ASSETBUNDLE) as AssetBundle;
            m_request = bundle.LoadAssetAsync (m_resPath.ToLower ()); // AssetBundle中所有资源名称和路径都是小写
        }

        public override void exit ()
        {
            FResManager.getInstance ().setRes (m_resId, m_request.asset);
        }

        public override void process ()
        {
        }

        public override bool isDone ()
        {
            if (m_request == null)
                return false;
            
            return m_request.isDone;
        }
    }

}
