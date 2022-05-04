using System.Collections.Generic;

namespace HosseinPan.Core
{
    public partial class StateMachine
    {
        private class Transition
        {
            private List<ITransitionCondition> _conditions;

            public IState ToState { get; }

            public Transition(IState toState, List<ITransitionCondition> conditions)
            {
                ToState = toState;
                _conditions = conditions;
            }

            public bool CheckConditions()
            {
                bool result = true;

                foreach (var condition in _conditions)
                {
                    if (condition.IsMet == false)
                    {
                        result = false;
                        break;
                    }
                }

                return result;
            }

            public void ResetConditions()
            {
                foreach (var condition in _conditions)
                {
                    condition.Reset();
                }
            }
        }
    }
}
