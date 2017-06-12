using UnityEngine;
using System.Collections;

namespace Pomelo
{
    public class GCommandTest : MonoBehaviour
    {
        public Transform m_itemParent;

        void OnEnable ()
        {
            float interval = 0.5f;
            GCommandManager ctrl = GCommandManager.create ();
            ctrl.execute ();
        }

        // Update is called once per frame
        void Update ()
        {

        }
    }
}
