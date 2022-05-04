using System;

namespace HosseinPan.Core
{
    public class ConditionWithReset
    {
        public Func<bool> Condition = default;
        public Action ResetCondition = default;
    }
}
