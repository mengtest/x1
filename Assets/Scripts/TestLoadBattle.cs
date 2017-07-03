using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace x1.Game
{
    using x1.Framework;

    public class TestLoadBattle : MonoBehaviour
    {

        // Use this for initialization
        void Start ()
        {
            FSequence seq = new FSequence ();
            seq.addAction (new GLoadBattle (GBattleBase.getInstance ()));
            this.runAction (seq);
        }
	
        // Update is called once per frame
        void Update ()
        {
		
        }
    }
}
