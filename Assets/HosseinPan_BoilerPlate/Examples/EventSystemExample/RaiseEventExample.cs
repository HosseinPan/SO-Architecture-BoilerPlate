using UnityEngine;
using HosseinPan.Core;

namespace HosseinPan.Examples
{
    public class RaiseEventExample : MonoBehaviour
    {
        private FloatEventSO _floatEventExample;

        private void InitializeSOs()
        {
            _floatEventExample = CommonSO.Events.FloatEventExample;
        }

        private void Awake()
        {
            InitializeSOs();
        }

        private void RaiseEvent(float value)
        {
            _floatEventExample.RaiseEvent(value);
        }

    }
}
