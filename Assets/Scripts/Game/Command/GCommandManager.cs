using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Pomelo
{
    public class GResID
    {
        public const int ASSETBUNDLE = 1;
        public const int TEXTURE2D = 2;
    }

    public class GCommandManager : MonoBehaviour
    {
        private Queue<GCommand> m_CommandQueue;

        private bool m_isRunning;

        private GCommand m_currentCommand;

        private Dictionary<int, System.Object> m_currentData;

        public static GCommandManager create ()
        {
            GameObject go = new GameObject ("GCommandController");
            GCommandManager controller = go.AddComponent<GCommandManager> ();
            return controller;
        }

        void Awake ()
        {
            m_CommandQueue = new Queue<GCommand> ();
            m_isRunning = false;
            m_currentCommand = null;
            m_currentData = new Dictionary<int, object> ();
        }

        void Update ()
        {
            if (m_isRunning == false)
                return;
            
            if (m_currentCommand == null) {
                if (m_CommandQueue.Count == 0) {
                    m_isRunning = false;
                } else {
                    m_currentCommand = m_CommandQueue.Dequeue ();
                    m_currentCommand.init (this);
                    m_currentCommand.enter ();
                }
                return;
            }
            
            if (m_currentCommand.isDone ()) {
                m_currentCommand.exit ();
                m_currentCommand = null;
                return;
            }
            
            m_currentCommand.process ();
        }

        public void add (GCommand Command)
        {
            m_CommandQueue.Enqueue (Command);
        }

        public void setData (int resId, System.Object res)
        {
            m_currentData [resId] = res;
        }

        public System.Object getData (int resId)
        {
            System.Object obj = null;
            m_currentData.TryGetValue (resId, out obj);
            return obj;
        }

        public void execute ()
        {
            m_isRunning = true;
        }
    }
}
