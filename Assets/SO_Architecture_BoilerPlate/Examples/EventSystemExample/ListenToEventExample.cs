using UnityEngine;
using HosseinPan.Core;
using System;

namespace HosseinPan.Examples
{
    public class ListenToEventExample : MonoBehaviour
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

        private void OnEnable()
        {
            _floatEventExample.Subscribe(OnFloatEventExample);
        }

        private void OnDisable()
        {
            _floatEventExample.Unsubscribe(OnFloatEventExample);
        }

        private void OnFloatEventExample(float value)
        {
            throw new NotImplementedException();
        }

    }
}
