using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Pomelo
{
    public class GCommandManager : MonoBehaviour
    {
        private Queue<GCommand> m_CommandQueue;

        private bool m_isRunning;

        private bool m_isDone;

        private GCommand m_currentCommand;

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
            m_isDone = false;
            m_currentCommand = null;
        }

        void Update ()
        {
            if (m_isRunning == false)
                return;
            
            if (m_currentCommand == null) {
                if (m_CommandQueue.Count == 0) {
                    m_isRunning = false;
                    m_isDone = true;
                } else {
                    m_currentCommand = m_CommandQueue.Dequeue ();
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

        public void execute ()
        {
            m_isRunning = true;
            m_isDone = false;
        }
    }
}
