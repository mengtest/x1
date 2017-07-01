/// <summary>
/// 异步加载AssetBundle中的资源
/// </summary>

using System;

namespace x1.Framework
{
    public class FLoadBundleAsset : FAction
    {
        private int m_resId;

        private string m_resPath;

        private UnityEngine.AssetBundleRequest m_request;

        public FLoadBundleAsset (int resId, string resPath)
        {
            m_resId = resId;
            m_resPath = resPath;
            m_request = null;
        }

        public override void start ()
        {
            UnityEngine.AssetBundle bundle = FResManager.getInstance ().getRes (FResID.ASSETBUNDLE) as UnityEngine.AssetBundle;
            m_request = bundle.LoadAssetAsync (m_resPath.ToLower ()); // AssetBundle中所有资源名称和路径都是小写
        }

        public override void stop ()
        {
            FResManager.getInstance ().setRes (m_resId, m_request.asset);
        }

        public override bool isDone ()
        {
            return m_request.isDone;
        }
    }
}

