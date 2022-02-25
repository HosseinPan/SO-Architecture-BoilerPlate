using System;
using System.Collections.Generic;

namespace HosseinPan.Core
{
    public partial class StateMachine
    {
        private class TransitionState
        {
            private ITransitionCondition[] _conditions;
            private Action _subscribeEvents;
            private Action _unsubscribeEvents;

            public IState To { get; }

            public TransitionState(IState to,
                                    List<VoidEventSO> eventsCondition,
                                    Func<bool> _statement, Action _resetStatement)
            {
                To = to;

                var eventListCondition = new EventListCondition(eventsCondition);
                _subscribeEvents = eventListCondition.SubscribeEvents;
                _unsubscribeEvents = eventListCondition.UnsubscribeEvents;

                var statementCondition = new StatementCondition()
                {
                    Condition = _statement,
                    ResetCondition = _resetStatement
                };

                _conditions = new ITransitionCondition[2];
                _conditions[0] = eventListCondition;
                _conditions[1] = statementCondition;
            }

            public TransitionState(IState to,
                                    List<VoidEventSO> eventsCondition)
            {
                To = to;

                var eventListCondition = new EventListCondition(eventsCondition);
                _subscribeEvents = eventListCondition.SubscribeEvents;
                _unsubscribeEvents = eventListCondition.UnsubscribeEvents;

                _conditions = new ITransitionCondition[1];
                _conditions[0] = eventListCondition;
            }

            public TransitionState(IState to,
                                    Func<bool> _statement, Action _resetStatement)
            {
                To = to;

                var statementCondition = new StatementCondition()
                {
                    Condition = _statement,
                    ResetCondition = _resetStatement
                };

                _conditions = new ITransitionCondition[1];
                _conditions[0] = statementCondition;
            }

            public bool CheckConditions()
            {
                bool result = true;

                for (int i = 0; i < _conditions.Length; i++)
                {
                    if (_conditions[i].IsMet == false)
                    {
                        result = false;
                        break;
                    }
                }

                return result;
            }

            public void ResetConditions()
            {
                for (int i = 0; i < _conditions.Length; i++)
                {
                    _conditions[i].Reset();
                }
            }

            public void SubscribeEvents()
            {
                _subscribeEvents?.Invoke();
            }

            public void UnsubscribeEvents()
            {
                _unsubscribeEvents?.Invoke();
            }

        }
    }
}
