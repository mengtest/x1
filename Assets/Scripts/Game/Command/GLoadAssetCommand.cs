using UnityEngine;
using System.Collections;

namespace x1.Game
{
    using x1.Framework;

    public class GLoadAssetCommand : GCommand
    {
        private int m_resId;

        private string m_resPath;

        private ResourceRequest m_request;

        public GLoadAssetCommand (int resId, string resPath)
        {
            m_resId = resId;
            m_resPath = resPath;
            m_request = null;
        }

        public override void enter ()
        {
            System.Type resType = typeof (UnityEngine.Object);
            if (m_resId == FResID.ASSETBUNDLE) {
            } else if (m_resId == FResID.PREFAB) {
                
            } else if (m_resId == FResID.TEXTURE) {
                resType = typeof (Texture);
            } else if (m_resId == FResID.SPRITE) {
                resType = typeof (Sprite);
            } else if (m_resId == FResID.FONT) {
            } else if (m_resId == FResID.AUDIO) {
            } else if (m_resId == FResID.FX) {
            }

            m_request = Resources.LoadAsync (m_resPath, resType);
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
            return m_request.isDone;
        }
    }

}
