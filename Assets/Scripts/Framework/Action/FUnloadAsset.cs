using System;

namespace x1.Framework
{
    public class FUnloadAsset : FAction
    {
        public int m_resId;

        public FUnloadAsset (int resId)
        {
            m_resId = resId;
        }

        public override void start ()
        {
        }

        public override void stop ()
        {
            UnityEngine.Object res = FResManager.getInstance ().getRes (m_resId);
            switch (m_resId) {
            case FResID.ASSETBUNDLE:
                (res as UnityEngine.AssetBundle).Unload (false);
                break;
            case FResID.PREFAB:
                // UnloadAsset may only be used on individual assets and can not be used on GameObject's / Components or AssetBundles
                break;
            case FResID.TEXTURE:
                UnityEngine.Resources.UnloadAsset (res);
                break;
            case FResID.SPRITE:
                UnityEngine.Resources.UnloadAsset (res);
                break;
            case FResID.FONT:
                UnityEngine.Resources.UnloadAsset (res);
                break;
            case FResID.AUDIO:
                UnityEngine.Resources.UnloadAsset (res);
                break;
            case FResID.FX:
                UnityEngine.Resources.UnloadAsset (res);
                break;
            default:
                UnityEngine.Resources.UnloadAsset (res);
                break;
            }
            FResManager.getInstance ().setRes (m_resId, null);
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}

