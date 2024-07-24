using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


namespace StolenPadCase
{
    internal class EnemySpawnManager : MonoBehaviour
    {
        [SerializeField] internal Transform spawnPos;
        [SerializeField] private float _spawnRadius;
        [SerializeField] internal ParticleSystem spawnFx;
        [SerializeField] private int _maxEnemyRoundCount;
        
        

        private GameManager gm;

        private void Start()
        {
            gm = GameManager.Instance;
        }
        

        internal void SpawnEnemies()
        {
           
            RoundData currentRoundData = gm.roundManager.roundDatas[gm.roundManager.currentRound];
            _maxEnemyRoundCount = currentRoundData.meleeEnemyCount + currentRoundData.rangerEnemyCount;
            SpawnEnemyType(ObjectType.skeleton, currentRoundData.meleeEnemyCount);
            SpawnEnemyType(ObjectType.evilMage, currentRoundData.rangerEnemyCount);
        }

        private void SpawnEnemyType(ObjectType enemyType, int count)
        {
             spawnFx.Play();
            for (int i = 0; i < count; i++)
            {
                Vector3 randomPoint = UnityEngine.Random.onUnitSphere;
                
                randomPoint.y = 0f;
               
                Vector3 spawnPosition = spawnPos.position + randomPoint * _spawnRadius;
                
                GameObject spawnedEnemy = GameManager.Instance.poolManager.GetPooledObject(objectType: enemyType);
                spawnedEnemy.transform.position = spawnPosition;
                
            }
        }

        internal void CheckSpawningDone()
        {
            if (_maxEnemyRoundCount == GameManager.Instance._enemyControllers.Count)
            {
                spawnFx.Stop();
            }
        }

    }

}
