using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public class EnemyHealthControl : MonoBehaviour
    {
        [SerializeField] private EnemyController _selfEnemyController;
        [SerializeField] private HealthBarController _selfHealthBarController;
        [SerializeField] private int _enemyType;
        [SerializeField] private int  _enemyHealth;
        [SerializeField] private int  _enemyFirstHealth;
        
        private void OnEnable()
        {
            
            _enemyFirstHealth = _selfEnemyController._enemyData.health;
            _enemyHealth = _enemyFirstHealth;
        }

        private void Start()
        {
            _selfHealthBarController.InitializeBar(_enemyHealth);
        }

        internal void GetDamage(int damage)
        {
            
            _enemyHealth -= damage;
            _selfEnemyController.selfStretchEffectController.EnemyStretch(.4f,1.3f);
            if (_enemyHealth > 0)
            {
                _selfHealthBarController.HealthUpdate(_enemyHealth);
                StartCoroutine(_selfEnemyController.selfStretchEffectController.ChangeColor());
            }
           
        }

        internal void DeathControl()
        {
            if (_enemyHealth <= 0)
            {
                _selfHealthBarController.DeathFx(_selfEnemyController.transform);
                GameManager.Instance.roundManager.NightEndChecker();
                GameManager.Instance._enemyControllers.Remove(_selfEnemyController);
                _selfEnemyController.isInList = false;
                GameManager.Instance.poolManager.SetPooledObject(gameObject, _enemyType);
                
            }
        }

        
        
    } 
}

