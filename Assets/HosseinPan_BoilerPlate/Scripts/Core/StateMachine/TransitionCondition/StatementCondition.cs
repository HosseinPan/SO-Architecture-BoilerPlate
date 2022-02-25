using System;

namespace HosseinPan.Core
{
    public partial class StateMachine
    {
        private class StatementCondition : ITransitionCondition
        {
            public Func<bool> Condition = default;
            public Action ResetCondition = default;

            public bool IsMet => Condition();

            public void Reset()
            {
                ResetCondition?.Invoke();
            }
        }
    }
}
