using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace berry
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager m_inst;

        public static GameManager getInstance ()
        {
            if (m_inst == null)
                m_inst = new GameManager ();
            return m_inst;
        }

        public List<ICommand> m_commandList;

        void Awake ()
        {
            m_inst = this;
            m_commandList = new List<ICommand> ();
        }

        void Start ()
        {
            startGame ();
        }

        void FixedUpdate ()
        {
            processCommands ();
        }

        void processCommands ()
        {
            int cmdNum = m_commandList.Count;
            for (int i = cmdNum - 1; i >= 0; --i) { // 倒序遍历,为了支持循环过程中删除元素
                m_commandList [i].process ();
            }
        }

        void startGame ()
        {
            GCommandSequence cmdSeq = new GCommandSequence ();
            cmdSeq.addCommand (new GCreateBattle (1));
            cmdSeq.addCommand (new GBattleLoadUI ());
            cmdSeq.addCommand (new GBattleInitUI ());
            cmdSeq.execute ();
        }
    }
}
