using UnityEngine;
using System.Collections;

namespace x1.Game
{
    public interface ICommand
    {
        void enter ();
        
        void exit ();

        void process ();

        bool isDone ();
    }

    public class GCommand : ICommand
    {
        public virtual void enter ()
        {
        }

        public virtual void exit ()
        {
        }
        
        public virtual void process ()
        {
        }

        public virtual bool isDone ()
        {
            return false;
        }
    }
}
