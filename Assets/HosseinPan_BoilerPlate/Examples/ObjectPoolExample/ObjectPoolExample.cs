using UnityEngine;
using HosseinPan.Core;

namespace HosseinPan.Examples
{
    public class ObjectPoolExample : MonoBehaviour
    {
        public GameObject dummyPrefab;

        private ObjectPoolSO _objectPool;
        private GameObject dummyGameObject;

        private void InitializeSOs()
        {
            _objectPool = CommonSO.Managers.ObjectPool;
        }

        private void Awake()
        {
            InitializeSOs();
        }

        private void GetNewGameObject(float value)
        {
            dummyGameObject = _objectPool.Get(dummyPrefab);
            dummyGameObject.SetActive(true);
        }

        private void ReturnToPool()
        {
            _objectPool.ReturnToPool(dummyGameObject);
        }
    }
}
