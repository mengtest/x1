using UnityEngine;
using System.Collections;

namespace berry
{
    public class GBattleLoadUI : GCommand
    {
        private GCommandSequence m_cmdSeq;

        private bool m_isDone;

        public GBattleLoadUI ()
        {
        }

        public override void enter ()
        {
            GBattleBase battle = GBattleBase.m_currentBattle;
            var canvas = LuaHelper.getCanvas ();

            m_isDone = false;
            m_cmdSeq = new GCommandSequence ();

            m_cmdSeq.addCommand (new GLoadAssetCommand (FResID.PREFAB, "GUI/UILoading"));
//            for (int i = 0; i < 100; i++) {
//                m_cmdSeq.addCommand (new GGenGameObjectCommand (canvas.transform));
//            }
//            m_cmdSeq.addCommand (new GLoadBundleCommand ("C:/xampp/htdocs/android/0.0.0.1/assetbundle/assets/resources/texture/items/item_03_003_0013.png"));
//            m_cmdSeq.addCommand (new GLoadBundleAssetCommand (FResID.TEXTURE, "assets/resources/texture/items/item_03_003_0013.png"));

            m_cmdSeq.addCommand (new GLoadAssetCommand (FResID.SPRITE, "Texture/item_04_043"));
            m_cmdSeq.addCommand (new GGenImageCommand (canvas.transform));
//            m_cmdSeq.addCommand (new GUnloadAssetCommand (FResID.ASSETBUNDLE));
            m_cmdSeq.execute ();
            Debug.Log ("加载游戏UI");
        }

        public override void process ()
        {
            m_isDone = m_cmdSeq.isDone ();
        }

        public override bool isDone ()
        {
            return m_isDone;
        }
    }
}
