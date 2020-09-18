﻿using System;
using System.Collections;
using UnityEngine;

namespace SpaceWar
{
    public class PooledMonoBehaviour : MonoBehaviour
    {
        [SerializeField] private int initialPoolSize = 25;

        public event Action<PooledMonoBehaviour> OnReturnToPool = delegate { };
        public UnityEngine.Events.UnityEvent OnDisabled;

        public int InitialPoolSize => initialPoolSize;

        public T Get<T>(bool enable = true) where T : PooledMonoBehaviour
        {
            var pool = Pool.GetPool(this);
            var pooledObject = pool.Get<T>();

            if (enable)
            {
                pooledObject.gameObject.SetActive(true);
            }
            return pooledObject;
        }

        public T Get<T>(Vector3 position, Quaternion rotation) where T : PooledMonoBehaviour
        {
            var pooledObject = Get<T>();

            pooledObject.transform.position = position;
            pooledObject.transform.rotation = rotation;

            return pooledObject;
        }

        protected virtual void OnDisable()
        {
            OnReturnToPool?.Invoke(this);
            OnDisabled?.Invoke();
        }

        public void ReturnToPool(float delay = 0)
        {
            StartCoroutine(ReturnToPoolAfterSeconds(delay));
        }

        private IEnumerator ReturnToPoolAfterSeconds(float delay)
        {
            yield return new WaitForSeconds(delay);
            gameObject.SetActive(false);
        }
    }
}