using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace berry
{
    public class GCommandSequence : GCommand
    {
        private bool m_isDone;
        
        private bool m_isRunning;
        
        private ICommand m_currentCmd;
        
        private Queue<ICommand> m_cmdQueue;

        public GCommandSequence ()
        {
            m_cmdQueue = new Queue<ICommand> ();
        }

        public void addCommand (ICommand cmd)
        {
            m_cmdQueue.Enqueue (cmd);
        }

        public override void enter ()
        {
            m_isDone = false;
            m_isRunning = true;
            m_currentCmd = null;

            GameManager.getInstance ().m_commandList.Add (this);
        }

        public override void exit ()
        {
            GameManager.getInstance ().m_commandList.Remove (this);
        }

        public override void process ()
        {
            if (m_isRunning == false)
                return;
            
            if (m_currentCmd == null) {
                if (m_cmdQueue.Count == 0) {
                    m_isRunning = false;
                    m_isDone = true;
                } else {
                    m_currentCmd = m_cmdQueue.Dequeue ();
                    m_currentCmd.enter ();
                }
                return;
            }
            if (m_currentCmd.isDone () == true) {
                m_currentCmd.exit ();
                m_currentCmd = null;
                return;
            }

            m_currentCmd.process ();
        }

        public override bool isDone ()
        {
            return m_isDone;
        }

        public void execute ()
        {
            
            enter ();
        }
    }
}
