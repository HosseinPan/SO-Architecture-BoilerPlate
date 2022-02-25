using HosseinPan.Core;
using UnityEngine;

namespace HosseinPan.Examples
{
    public class FirstState : IState
    {
        public void OnEnter()
        {
            Debug.Log("Entered First State");
        }

        public void OnExit()
        {
            Debug.Log("Exited from First State");
        }

        public void Tick()
        {

        }
    }
}
