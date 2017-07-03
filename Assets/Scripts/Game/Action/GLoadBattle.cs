using System;
using UnityEngine;
using UnityEngine.UI;

namespace x1.Game
{
    using x1.Framework;

    public class GLoadBattle : FAction
    {
        private GBattleBase m_battle;

        public GLoadBattle (GBattleBase battle)
        {
            m_battle = battle;
        }

        public override void start (System.Object obj)
        {
            GameObject panel = GameObject.Find ("UILoadBattlePanel");
            IBattleUnit[] units = m_battle.getUnits ();
            FSequence seq = new FSequence ();
            foreach (var unit in units) {
                GRoleUnit role = unit as GRoleUnit;
                if (role != null) {
                    Image img = panel.transform.FindChild ("image_" + role.getRoleId ()).GetComponent<Image> ();
                    uint skin = role.getSkinId ();
                    IHero hero = role.getHero ();
                    string skinFile = hero.getSkinTexture (skin);
                    seq.addAction (new FLoadAsset (FResID.SPRITE, "Texture/hero/" + skinFile)); // 加载对应皮肤的图片
                    seq.addAction (new FCallFunc (delegate() {
                        img.sprite = FResManager.getInstance ().getRes (FResID.SPRITE) as Sprite; // 显示皮肤图片
                    }));
                    seq.addAction (new FUnloadAsset (FResID.SPRITE));
                    UnityEngine.Debug.Log (role.getHero ().getSkinTexture (role.getSkinId ()));
                }
            }
            this.runAction (seq);
        }

        public override bool isDone ()
        {
            return true;
        }
    }
}

