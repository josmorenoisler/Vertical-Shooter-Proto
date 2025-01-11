using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

namespace VerticalShooter
{
    public class EnemySpawner : MonoBehaviour 
    {
        [SerializeField] List<EnemyType> enemyTypes;
        [SerializeField] int maxEnemies = 6;
        [SerializeField] float spawnInterval = 2f;

        List<SplineContainer> splines;
        EnemyFactory enemyFactory;
        float spawnTimer;
        int enemiesSpawned;

        void OnValidate()
        {
            splines = new List<SplineContainer>(GetComponentsInChildren<SplineContainer>());
        }

        void Start()
        {
            enemyFactory = new EnemyFactory();    
        }

        void Update()
        {
            spawnTimer += Time.deltaTime;

            if (enemiesSpawned < maxEnemies && spawnTimer >= spawnInterval) 
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }

        void SpawnEnemy()
        {
            EnemyType enemyType = enemyTypes[UnityEngine.Random.Range(0, enemyTypes.Count)];
            SplineContainer splineContainer = splines[UnityEngine.Random.Range(0, splines.Count)];

            enemyFactory.CreateEnemy(enemyType, splineContainer); // pool enemies??
            enemiesSpawned++;
        }
    }
}
