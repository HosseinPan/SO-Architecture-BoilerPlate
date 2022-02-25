using System.Collections.Generic;
using UnityEngine;

namespace HosseinPan.Core
{
    public class ObjectPoolSO : BaseSO
    {
        private Dictionary<GameObject, List<GameObject>> _pools;

        public void ReturnToPool(GameObject gameObjectToReturn)
        {
            CheckForInitializePools();

            var poolKey = gameObjectToReturn.GetComponent<PoolKey>();
            if (poolKey == null ||
                _pools.ContainsKey(poolKey.PoolKeyPrefab) == false)
            {
                Debug.LogWarning($"Object ' {gameObjectToReturn.name} not belong to any pool. GameObject.Destroy called.");
                GameObject.Destroy(gameObjectToReturn);
                return;
            }

            gameObjectToReturn.SetActive(false);
            _pools[poolKey.PoolKeyPrefab].Add(gameObjectToReturn);
        }

        public GameObject Get(GameObject prefab)
        {
            CheckForInitializePools();
            CheckForCreateNewPool(prefab);

            if (_pools[prefab].Count == 0)
            {
                AddNewGameObjectToPool(prefab);
            }

            GameObject result = _pools[prefab][0];
            _pools[prefab].RemoveAt(0);
            return result;
        }

        public void PreLoad(GameObject prefab, int count)
        {
            CheckForInitializePools();
            CheckForCreateNewPool(prefab);

            for (int i = 0; i < count; i++)
            {
                AddNewGameObjectToPool(prefab);
            }
        }

        private void AddNewGameObjectToPool(GameObject prefab)
        {
            var newObj = Instantiate(prefab);
            newObj.SetActive(false);
            newObj.AddComponent<PoolKey>().PoolKeyPrefab = prefab;
            _pools[prefab].Add(newObj);
        }

        private void CheckForInitializePools()
        {
            if (_pools == null)
            {
                _pools = new Dictionary<GameObject, List<GameObject>>();
            }
        }

        private void CheckForCreateNewPool(GameObject prefab)
        {
            if (_pools.ContainsKey(prefab) == false)
            {
                _pools[prefab] = new List<GameObject>();
            }
        }

        class PoolKey : MonoBehaviour
        {
            public GameObject PoolKeyPrefab;
        }
    }
}