using HosseinPan.Core;
using UnityEngine;

namespace HosseinPan.Examples
{
    public class SecondState : IState
    {
        public void OnEnter()
        {
            Debug.Log("Entered Second State");
        }

        public void OnExit()
        {
            Debug.Log("Exited from Second State");
        }

        public void Tick()
        {

        }
    }
}