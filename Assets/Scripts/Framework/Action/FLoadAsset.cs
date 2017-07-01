/// <summary>
/// 异步加载资源
/// </summary>

using System;

namespace x1.Framework
{
    public class FLoadAsset : FAction
    {
        private int m_resId;

        private string m_resPath;

        private UnityEngine.ResourceRequest m_request;

        public FLoadAsset (int resId, string resPath)
        {
            m_resId = resId;
            m_resPath = resPath;
            m_request = null;
        }

        public override void start ()
        {
            System.Type resType = null;
            switch (m_resId) {
            case FResID.ASSETBUNDLE:
                resType = typeof(UnityEngine.Object);
                break;
            case FResID.PREFAB:
                resType = typeof(UnityEngine.Object);
                break;
            case FResID.TEXTURE:
                resType = typeof(UnityEngine.Texture);
                break;
            case FResID.SPRITE:
                resType = typeof(UnityEngine.Sprite);
                break;
            case FResID.FONT:
                resType = typeof(UnityEngine.Object);
                break;
            case FResID.AUDIO:
                resType = typeof(UnityEngine.Object);
                break;
            case FResID.FX:
                resType = typeof(UnityEngine.Object);
                break;
            default:
                resType = typeof(UnityEngine.Object);
                break;
            }

            m_request = UnityEngine.Resources.LoadAsync (m_resPath, resType);
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

