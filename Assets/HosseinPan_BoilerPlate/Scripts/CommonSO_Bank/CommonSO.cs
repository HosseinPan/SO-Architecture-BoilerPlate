using HosseinPan.Core.CommonSOs;
using UnityEngine;

namespace HosseinPan.Core
{
    [DefaultExecutionOrder(-1)]
    public class CommonSO : MonoBehaviour
    {
        [SerializeField] private CommonEvents events;
        [SerializeField] private CommonManagers managers;
        [SerializeField] private CommonSharedData sharedData;

        public static CommonEvents Events
        {
            get
            {
                return _instance.events;
            }
        }

        public static CommonManagers Managers
        {
            get
            {
                return _instance.managers;
            }
        }

        public static CommonSharedData SharedData
        {
            get
            {
                return _instance.sharedData;
            }
        }

        private static CommonSO _instance;

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Debug.LogError("More than one Instance of CommonSO");
            }
            else
            {
                _instance = this;
            }
        }
    }
}