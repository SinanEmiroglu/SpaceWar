using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SpaceWar
{
    public class Pool : MonoBehaviour
    {
        public static Dictionary<PooledMonoBehaviour, Pool> Pools = new Dictionary<PooledMonoBehaviour, Pool>();

        private const string _poolSceneName = "Pools";

        private Queue<PooledMonoBehaviour> _objects = new Queue<PooledMonoBehaviour>();
        private HashSet<PooledMonoBehaviour> _availableObjects = new HashSet<PooledMonoBehaviour>();
        private PooledMonoBehaviour _prefab;

        public static Pool GetPool(PooledMonoBehaviour prefab)
        {
            if (Pools.ContainsKey(prefab))
            {
                return Pools[prefab];
            }

            var poolGameObject = new GameObject("Pool - " + prefab.name);
            var pool = poolGameObject.AddComponent<Pool>();

            if (!SceneManager.GetSceneByName(_poolSceneName).isLoaded)
            {
                SceneManager.LoadScene(_poolSceneName, LoadSceneMode.Additive);
            }

            SceneManager.MoveGameObjectToScene(poolGameObject, SceneManager.GetSceneByName(_poolSceneName));

            pool._prefab = prefab;

            Pools.Add(prefab, pool);
            return pool;
        }

        public T Get<T>() where T : PooledMonoBehaviour
        {
            if (_objects.Count == 0)
            {
                GrowPool();
            }

            var pooledObject = _objects.Dequeue();

            return pooledObject as T;
        }

        public void ReturnAllToPool()
        {
            foreach (var pooled in _availableObjects)
            {
                pooled.ReturnToPool();
            }
        }

        private void GrowPool()
        {
            for (int i = 0; i < _prefab.InitialPoolSize; i++)
            {
                var pooledObject = Instantiate(_prefab);

                _availableObjects.Add(pooledObject);

                pooledObject.gameObject.name = $"{_prefab.name} {i}";
                pooledObject.OnReturnToPool += AddObjectToAvailableQueue;
                pooledObject.transform.SetParent(transform);
                pooledObject.gameObject.SetActive(false);
            }
        }

        private void AddObjectToAvailableQueue(PooledMonoBehaviour pooledObject)
        {
            pooledObject.transform.SetParent(transform);
            _objects.Enqueue(pooledObject);
        }
    }
}