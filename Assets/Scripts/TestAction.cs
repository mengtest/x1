﻿using UnityEngine;
using System.Collections;

using x1.Framework;

public class TestAction : MonoBehaviour
{
    public Transform m_target;

    // Use this for initialization
    void Start ()
    {
        FActionManager.getInstance ().init ();

        FSequence seq = new FSequence ();
#if false
        FSpawn spawn1 = new FSpawn ();
        spawn1.addAction (new FMoveTo (1f, Vector2.right * 10));
        spawn1.addAction (new FScaleTo (1f, Vector3.one * 5));
        FSpawn spawn2 = new FSpawn ();
        spawn2.addAction (new FMoveTo (1f, Vector3.left * 10));
        spawn2.addAction (new FScaleTo (1f, Vector3.one));
        seq.addAction (spawn1);
        seq.addAction (spawn2);
#endif
#if true
        seq.addAction (new FScaleTo (1f, Vector3.one * 5));
        seq.addAction (new FScaleTo (1f, Vector3.zero));
#endif
        m_target.runAction (new FRepeatForever (seq));
    }
    
    // Update is called once per frame
    void Update ()
    {
        FActionManager.getInstance ().step ();
    }
}

