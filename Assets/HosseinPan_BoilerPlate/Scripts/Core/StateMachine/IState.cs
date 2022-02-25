namespace HosseinPan.Core
{
    public interface IState
    {
        /// <summary>
        /// Called when entering a state.
        /// </summary>
        void OnEnter();

        /// <summary>
        /// Called when leaving a state.
        /// </summary>
        void OnExit();

        /// <summary>
        /// Called on Every Tick
        /// </summary>
        void Tick();
    }
}
