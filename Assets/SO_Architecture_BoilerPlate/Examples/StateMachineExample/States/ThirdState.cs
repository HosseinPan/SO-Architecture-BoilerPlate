using HosseinPan.Core;
using UnityEngine;

namespace HosseinPan.Examples
{
    public class ThirdState : IState
    {
        public void OnEnter()
        {
            Debug.Log("Entered Third State");
        }

        public void OnExit()
        {
            Debug.Log("Exited from Third State");
        }

        public void Tick()
        {

        }
    }
}
