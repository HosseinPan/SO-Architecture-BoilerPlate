using System;

namespace HosseinPan.Core
{
    public abstract class BaseEventSO : BaseSO
    {
        private event Action _onEventRaised;

        public void Subscribe(Action listener)
        {
            _onEventRaised += listener;
        }

        public void Unsubscribe(Action listener)
        {
            _onEventRaised -= listener;
        }

        public void RaiseEvent()
        {
            _onEventRaised?.Invoke();
        }
    }

    public abstract class BaseEventSO<T> : BaseSO
    {
        private event Action<T> _onEventRaised;

        public void Subscribe(Action<T> listener)
        {
            _onEventRaised += listener;
        }

        public void Unsubscribe(Action<T> listener)
        {
            _onEventRaised -= listener;
        }

        public void RaiseEvent(T input)
        {
            _onEventRaised?.Invoke(input);
        }
    }

    public abstract class BaseEventSO<T1,T2> : BaseSO
    {
        private event Action<T1, T2> _onEventRaised;

        public void Subscribe(Action<T1, T2> listener)
        {
            _onEventRaised += listener;
        }

        public void Unsubscribe(Action<T1, T2> listener)
        {
            _onEventRaised -= listener;
        }

        public void RaiseEvent(T1 input1, T2 input2)
        {
            _onEventRaised?.Invoke(input1, input2);
        }
    }
}
