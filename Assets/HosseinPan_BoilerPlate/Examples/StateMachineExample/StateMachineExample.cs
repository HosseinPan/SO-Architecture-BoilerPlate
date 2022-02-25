using UnityEngine;
using HosseinPan.Core;
using System.Collections.Generic;
using System;

namespace HosseinPan.Examples
{
    public class StateMachineExample : MonoBehaviour
    {
        private VoidEventSO _conditionEvent1;
        private VoidEventSO _conditionEvent2;

        private StateMachine _stateMachine;

        private void InitializeSOs()
        {
            _conditionEvent1 = CommonSO.Events.ConditionEvent1;
            _conditionEvent2 = CommonSO.Events.ConditionEvent2;
        }

        private void Awake()
        {
            InitializeSOs();
            InitializeStateMachine();
        }

        private void OnEnable()
        {
            _stateMachine.OnEnable();
        }

        private void OnDisable()
        {
            _stateMachine.OnDisable();
        }


        private void Update()
        {
            _stateMachine.Tick();
        }

        private void InitializeStateMachine()
        {
            _stateMachine = new StateMachine();

            var firstState = new FirstState();
            var secondState = new SecondState();
            var thirdState = new ThirdState();

            _stateMachine.AddTransition(firstState, 
                                        secondState,
                                        new List<VoidEventSO>() { _conditionEvent1, _conditionEvent2 });

            _stateMachine.AddTransition(secondState, 
                                        thirdState,
                                        CheckThirdStateCondition,
                                        ResetThirdStateCondition);

            _stateMachine.SetState(firstState);
        }


        private bool CheckThirdStateCondition()
        {
            throw new NotImplementedException();
        }

        private void ResetThirdStateCondition()
        {
            throw new NotImplementedException();
        }
    }
}
