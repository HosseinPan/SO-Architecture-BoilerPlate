using System;
using System.Collections.Generic;

namespace HosseinPan.Core
{
    public partial class StateMachine
    {
        private Dictionary<Type, List<TransitionState>> _totalTransitions = new Dictionary<Type, List<TransitionState>>();
        private List<TransitionState> _currentTransitions = new List<TransitionState>();
        private static List<TransitionState> _emptyTransitions = new List<TransitionState>(0);

        private IState _currentState = default;

        public void Tick()
        {
            var transition = GetTransition();
            if (transition != null)
                SetState(transition.To);

            _currentState?.Tick();
        }

        public void SetState(IState state)
        {
            if (state == _currentState)
                return;

            _currentState?.OnExit();
            _currentState = state;

            ResetCurrentTransitionsConditions();

            _currentState?.OnEnter();
        }

        public void AddTransition(IState from, IState to,
                                    List<VoidEventSO> eventsCondition,
                                    Func<bool> statementCondition,
                                    Action resetCondition)
        {
            CheckForCreateNewTransitionKey(from);
            _totalTransitions[from.GetType()].Add(new TransitionState(to, eventsCondition, statementCondition, resetCondition));
        }

        public void AddTransition(IState from, IState to,
                                    List<VoidEventSO> eventsCondition)
        {
            CheckForCreateNewTransitionKey(from);
            _totalTransitions[from.GetType()].Add(new TransitionState(to, eventsCondition));
        }

        public void AddTransition(IState from, IState to,
                                    Func<bool> statementCondition,
                                    Action resetCondition)
        {
            CheckForCreateNewTransitionKey(from);
            _totalTransitions[from.GetType()].Add(new TransitionState(to, statementCondition, resetCondition));
        }



        public void OnEnable()
        {
            SubscribeConditionEvents();
        }

        public void OnDisable()
        {
            UnsubscribeConditionEvents();
        }

        private void CheckForCreateNewTransitionKey(IState fromState)
        {
            if (_totalTransitions.TryGetValue(fromState.GetType(), out var transitions) == false)
            {
                transitions = new List<TransitionState>();
                _totalTransitions[fromState.GetType()] = transitions;
            }
        }

        private void SubscribeConditionEvents()
        {
            foreach (var transitionList in _totalTransitions.Values)
            {
                if (transitionList != null)
                {
                    for (int i = 0; i < transitionList.Count; i++)
                    {
                        transitionList[i].SubscribeEvents();
                    }
                }
            }
        }

        private void UnsubscribeConditionEvents()
        {
            foreach (var transitionList in _totalTransitions.Values)
            {
                if (transitionList != null)
                {
                    for (int i = 0; i < transitionList.Count; i++)
                    {
                        transitionList[i].UnsubscribeEvents();
                    }
                }
            }
        }

        private TransitionState GetTransition()
        {
            for (int i = 0; i < _currentTransitions.Count; i++)
            {
                if (_currentTransitions[i].CheckConditions())
                {
                    return _currentTransitions[i];
                }
            }

            return null;
        }

        private void ResetCurrentTransitionsConditions()
        {
            _totalTransitions.TryGetValue(_currentState.GetType(), out _currentTransitions);
            if (_currentTransitions == null)
                _currentTransitions = _emptyTransitions;
            for (int i = 0; i < _currentTransitions.Count; i++)
            {
                _currentTransitions[i].ResetConditions();
            }
        }
    }
}
