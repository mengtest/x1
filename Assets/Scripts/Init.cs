using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

namespace x1.Game
{
    using x1.Framework;

    public class Init : MonoBehaviour
    {

        // Use this for initialization
        void Start ()
        {
            GameManager gameManager = gameObject.AddComponent<GameManager> ();
            gameManager.init ();
            gameManager.startGame ();
        }
    }
}