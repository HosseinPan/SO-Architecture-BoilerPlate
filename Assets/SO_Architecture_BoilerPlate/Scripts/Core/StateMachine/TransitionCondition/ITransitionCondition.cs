namespace HosseinPan.Core
{
    public partial class StateMachine
    {
        private interface ITransitionCondition
        {
            bool IsMet { get; }
            void Reset();
        }
    }
}
