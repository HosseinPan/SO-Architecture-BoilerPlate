using System;

namespace HosseinPan.Core
{
    public partial class StateMachine
    {
        private class StatementCondition : ITransitionCondition
        {
            private Func<bool> _condition = default;
            private Action _resetCondition = default;

            public bool IsMet => _condition();

            public StatementCondition(ConditionWithReset conditionWithReset)
            {
                _condition = conditionWithReset.Condition;
                _resetCondition = conditionWithReset.ResetCondition;
            }

            public void Reset()
            {
                _resetCondition?.Invoke();
            }
        }
    }
}
