using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SpaceWar
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private float respawnRate = 2;
        [SerializeField] private float initialSpawnDelay = 5;
        [SerializeField] private int numberToSpawnEachTime = 1;
        [SerializeField] private Transform[] spawnPoints;

        private bool _isSpawnable;
        private float _spawnTimer;
        private List<Spawnable> _spawnables = new List<Spawnable>();

        private void OnEnable()
        {
            _spawnTimer = respawnRate - initialSpawnDelay;
            GameManager.OnLevelLoaded += LevelLoadedHandler;
        }

        private void Update()
        {
            _spawnTimer += Time.deltaTime;

            if (ShouldSpawn())
            {
                Spawn();
            }
        }

        private void LevelLoadedHandler(LevelData data)
        {
            foreach (Spawnable prefab in data.SpawnablePrefabs)
            {
                _spawnables.Add(prefab);
            }

            _isSpawnable = true;
        }

        private void Spawn()
        {
            _spawnTimer = 0;
            var availableSpawnPoints = spawnPoints.ToList();

            for (int i = 0; i < numberToSpawnEachTime; i++)
            {
                Spawnable prefab = ChooseRandomPrefab();
                if (prefab != null)
                {
                    Transform spawnPoint = ChooseRandomSpawnPoint(availableSpawnPoints);

                    if (availableSpawnPoints.Contains(spawnPoint))
                    {
                        availableSpawnPoints.Remove(spawnPoint);
                    }

                    Spawnable npc = prefab.Get<Spawnable>(spawnPoint.position, spawnPoint.rotation);
                }
            }
        }

        private Transform ChooseRandomSpawnPoint(List<Transform> availableSpawnPoints)
        {
            if (availableSpawnPoints.Count == 0)
            {
                return transform;
            }
            if (availableSpawnPoints.Count == 1)
            {
                return availableSpawnPoints[0];
            }
            int index = Random.Range(0, availableSpawnPoints.Count);
            return availableSpawnPoints[index];
        }

        private Spawnable ChooseRandomPrefab()
        {
            if (_spawnables.Count == 0)
            {
                return null;
            }
            if (_spawnables.Count == 1)
            {
                return _spawnables[0];
            }
            int index = Random.Range(0, _spawnables.Count);
            return _spawnables[index];
        }

        private bool ShouldSpawn()
        {
            if (!_isSpawnable)
            {
                return false;
            }

            return _spawnTimer >= respawnRate;
        }

        private void OnDisable()
        {
            _isSpawnable = false;
            GameManager.OnLevelLoaded -= LevelLoadedHandler;
        }

#if UNITY_EDITOR

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(transform.position, Vector3.one);
            foreach (var spawnPoint in spawnPoints)
            {
                Gizmos.DrawSphere(spawnPoint.position, 0.2f);
            }
        }

#endif
    }
}