using UnityEngine;
using System.Collections;

using x1.Framework;

public class TestAction : MonoBehaviour
{

    // Use this for initialization
    void Start ()
    {
        FActionManager.getInstance ().init ();

        FSequence seq = new FSequence ();
        seq.addAction (new FMoveTo (1f, Vector2.right * 100));
        seq.addAction (new FMoveTo (1f, Vector3.left * 100));
        this.runAction (new FRepeat (3, seq));
    }
    
    // Update is called once per frame
    void Update ()
    {
        FActionManager.getInstance ().step ();
    }
}

