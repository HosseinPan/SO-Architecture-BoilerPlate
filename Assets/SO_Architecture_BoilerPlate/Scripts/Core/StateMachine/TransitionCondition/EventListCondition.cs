using System;
using System.Collections.Generic;

namespace HosseinPan.Core
{
    public partial class StateMachine
    {
        private class EventListCondition : ITransitionCondition
        {
            private List<VoidEventSO> _events;

            private List<bool> _doneEvents = default;
            private Action[] _responses = default;

            public bool IsMet { get; private set; }

            public EventListCondition(List<VoidEventSO> events)
            {
                IsMet = false;
                _events = events;
                _doneEvents = new List<bool>();

                if (_events != null)
                {
                    for (int i = 0; i < _events.Count; i++)
                    {
                        _doneEvents.Add(false);
                    }
                }

                CreateResponses();
            }

            public void Reset()
            {
                if (_doneEvents.Count == 0)
                {
                    IsMet = true;
                    return;
                }

                IsMet = false;

                for (int i = 0; i < _doneEvents.Count; i++)
                {
                    _doneEvents[i] = false;
                }
            }

            public void SubscribeEvents()
            {
                if (_responses == null || _responses.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < _events.Count; i++)
                {
                    int index = i; //used this code to prevent bug c# otherwise the index value won't be correct
                    _events[i].Subscribe(_responses[index]);
                }
            }

            public void UnsubscribeEvents()
            {
                if (_responses == null || _responses.Length == 0)
                {
                    return;
                }

                for (int i = 0; i < _events.Count; i++)
                {
                    int index = i; //used this code to prevent bug c# otherwise the index value won't be correct
                    _events[i].Unsubscribe(_responses[index]);
                }
            }

            private void CreateResponses()
            {
                if (_doneEvents.Count == 0)
                {
                    return;
                }

                _responses = new Action[_doneEvents.Count];

                for (int i = 0; i < _doneEvents.Count; i++)
                {
                    int index = i; //used this code to prevent bug c# otherwise the index value won't be correct
                    _responses[i] = () => OnEventElementRaise(index);
                }
            }

            private void OnEventElementRaise(int index)
            {
                if (IsMet)
                {
                    return;
                }

                _doneEvents[index] = true;
                SetIsMet();
            }

            private void SetIsMet()
            {
                if (IsMet)
                {
                    return;
                }

                for (int i = 0; i < _doneEvents.Count; i++)
                {
                    if (_doneEvents[i] == false)
                    {
                        return;
                    }
                }

                IsMet = true;
            }
        }
    }
}