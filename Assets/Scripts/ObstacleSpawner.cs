using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Jungle.Minigames.Chase
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Transform _obstaclePlacement;
        [SerializeField] private Obstacle _obstacleTemplate;
        [SerializeField] private float _minTimeToRespawn;
        [SerializeField] private float _maxTimeToRespawn;
        
        private List<Obstacle> _pool = new List<Obstacle>();
        private float _nextTimeToSpawn;
        private float _currentTime;

        private void Awake()
        {
            SpawnObstacle();
        }

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (_currentTime >= _nextTimeToSpawn)
            {
                SpawnObstacle();
                _currentTime = 0;
                GenerateNewTime();
            }
                
        }

        private void SpawnObstacle()
        {
            if (!HasFreeObstacleInPool(out var obstacle))
                _pool.Add(CreateNewObstacle());
            else
                SetNewPosition(obstacle);
        }
        
        private Obstacle CreateNewObstacle()
        {
            var obstacle = Instantiate(_obstacleTemplate, transform.position, transform.rotation, _obstaclePlacement);
            return obstacle;
        }

        private bool HasFreeObstacleInPool(out Obstacle obstacle)
        {
            obstacle = _pool.FirstOrDefault(obstacle => obstacle.enabled == false);
            return _pool.Any(obstacle => obstacle.enabled == false);
        }

        private void SetNewPosition(Obstacle obstacle)
        {
            obstacle.transform.position = transform.position;
            obstacle.enabled = true;
        }

        private void GenerateNewTime()
        {
            _nextTimeToSpawn = Random.Range(_minTimeToRespawn * 10, _maxTimeToRespawn * 10) / 10;
        }
    }
}
