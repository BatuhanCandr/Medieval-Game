using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace StolenPadCase
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] internal Enemy _enemyData;
        [SerializeField] internal EnemyAIController enemyAIController;
        [SerializeField] internal EnemyAnimationController _enAnimationController;
        [SerializeField] internal EnemyHealthControl selfHealthControl;
        
        [SerializeField] internal StretchEffectController selfStretchEffectController;
        
        [SerializeField] internal bool isInList;
        

        private void AddToList()
        {
            if (!isInList)
            {
                isInList = true;
                GameManager.Instance._enemyControllers.Add(this);
                GameManager.Instance.EnemySpawnManager.CheckSpawningDone();
            }
        
        }
        
        private void SetEnemy()
        {
            GameManager.Instance.poolManager.SetPooledObject(gameObject, 0);
        }
        
    }
}