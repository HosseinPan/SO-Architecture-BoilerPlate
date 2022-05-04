using System;
using System.Collections.Generic;

namespace HosseinPan.Core
{
    public partial class StateMachine
    {
        private Dictionary<Type, List<Transition>> _totalTransitions = new Dictionary<Type, List<Transition>>();
        private List<Transition> _currentTransitions = new List<Transition>();
        private static List<Transition> _emptyTransitions = new List<Transition>(0);

        private IState _currentState = default;
        private List<EventsCondition> _totalEventsConditions = new List<EventsCondition>();

        public void Tick()
        {
            var transition = GetTransition();
            if (transition != null)
                SetState(transition.ToState);

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

        public void AddTransition(TransitioningStates transitioningStates,
                                    List<VoidEventSO> conditionEvents,
                                    ConditionWithReset conditionWithReset)
        {
            var eventsCondition = CreateEventsCondition(conditionEvents);
            var statementCondition = new StatementCondition(conditionWithReset);

            var conditions = new List<ITransitionCondition>();           
            conditions.Add(eventsCondition);
            conditions.Add(statementCondition);

            CreateTransition(transitioningStates, conditions);
        }

        public void AddTransition(TransitioningStates transitioningStates,
                                    List<VoidEventSO> conditionEvents)
        {
            var eventsCondition = CreateEventsCondition(conditionEvents);

            var conditions = new List<ITransitionCondition>();
            conditions.Add(eventsCondition);

            CreateTransition(transitioningStates, conditions);
        }

        public void AddTransition(TransitioningStates transitioningStates,
                                    ConditionWithReset conditionWithReset)
        {
            var statementCondition = new StatementCondition(conditionWithReset);

            var conditions = new List<ITransitionCondition>();
            conditions.Add(statementCondition);

            CreateTransition(transitioningStates, conditions);
        }

        public void OnEnableGameObject()
        {
            SubscribeConditionEvents();
        }

        public void OnDisableGameObject()
        {
            UnsubscribeConditionEvents();
        }

        private EventsCondition CreateEventsCondition(List<VoidEventSO> conditionEvents)
        {
            var eventsCondition = new EventsCondition(conditionEvents);
            _totalEventsConditions.Add(eventsCondition);
            return eventsCondition;
        }

        private void AddTransitionTo_TotalTransitions(IState fromState, Transition transition)
        {
            CheckToCreateNewTransitionKey(fromState);
            _totalTransitions[fromState.GetType()].Add(transition);
        }

        private void CreateTransition(TransitioningStates transitioningStates, List<ITransitionCondition> conditions)
        {
            var transition = new Transition(transitioningStates.To, conditions);
            AddTransitionTo_TotalTransitions(transitioningStates.From, transition);
        }

        private void CheckToCreateNewTransitionKey(IState fromState)
        {
            if (_totalTransitions.TryGetValue(fromState.GetType(), out var transitions) == false)
            {
                transitions = new List<Transition>();
                _totalTransitions[fromState.GetType()] = transitions;
            }
        }

        private void SubscribeConditionEvents()
        {
            foreach (var eventsCondition in _totalEventsConditions)
            {
                eventsCondition.SubscribeEvents();
            }
        }

        private void UnsubscribeConditionEvents()
        {
            foreach (var eventsCondition in _totalEventsConditions)
            {
                eventsCondition.UnsubscribeEvents();
            }
        }

        private Transition GetTransition()
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
