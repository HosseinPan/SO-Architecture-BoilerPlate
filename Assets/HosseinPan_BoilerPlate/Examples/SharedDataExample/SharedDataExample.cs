using UnityEngine;
using HosseinPan.Core;

namespace HosseinPan.Examples
{
    public class SharedDataExample : MonoBehaviour
    {
        private FloatVariableSO _floatVariableExample;
        private IntListSO _intListExample;
        private void InitializeSOs()
        {
            _floatVariableExample = CommonSO.SharedData.FloatVariableExample;
            _intListExample = CommonSO.SharedData.IntListExample;
        }

        private void Awake()
        {
            InitializeSOs();
        }

        private void ReadVariable()
        {
            float value = _floatVariableExample.Value;
        }

        private void WriteVariable()
        {
            _floatVariableExample.Value = default;
        }

        private void ReadList()
        {
            for (int i = 0; i < _intListExample.Values.Count; i++)
            {
                _intListExample.Values[i] = default;
            }
        }

        private void WriteList()
        {
            _intListExample.Values.Add(0);
        }
    }
}
