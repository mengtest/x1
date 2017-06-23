using UnityEngine;
using System.Collections;

namespace berry
{

    public class GUnloadAssetCommand : GCommand
    {
        public int m_resId;

        public GUnloadAssetCommand (int resId)
        {
            m_resId = resId;
        }

        public override void enter ()
        {
        }

        public override void exit ()
        {
            UnityEngine.Object res = FResManager.getInstance ().getRes (m_resId);
            if (m_resId == FResID.ASSETBUNDLE) {
                (res as AssetBundle).Unload (false);
            } else if (m_resId == FResID.PREFAB) {
            } else if (m_resId == FResID.TEXTURE) {
            } else if (m_resId == FResID.SPRITE) {
            } else if (m_resId == FResID.FONT) {
            } else if (m_resId == FResID.AUDIO) {
            } else if (m_resId == FResID.FX) {
            }
            FResManager.getInstance ().setRes (m_resId, null);
        }

        public override void process ()
        {
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}
