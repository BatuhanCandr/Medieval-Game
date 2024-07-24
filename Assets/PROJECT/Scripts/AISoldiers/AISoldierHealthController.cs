using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public class AISoldierHealthController : MonoBehaviour
    {
        [SerializeField] private AISoldierController _aiSoldierController;
        [SerializeField] internal HealthBarController selfHealthBarController;
        [SerializeField] internal int soldierHealth;
        [SerializeField] private int  _maxHealth;
        
        private void Start()
        {
            _maxHealth = soldierHealth;
            selfHealthBarController.InitializeBar(soldierHealth);
            GameManager.Instance.trainBuildingController.soldierList.Add(this);
        }

        internal void GetDamage(int damage)
        {
            if (soldierHealth > 0)
            {
                selfHealthBarController.HealthUpdate(soldierHealth);
                StartCoroutine( _aiSoldierController.selfStretchEffectController.ChangeColor());
            }
            soldierHealth -= damage;
            
            _aiSoldierController.selfStretchEffectController.EnemyStretch(.4f,1.3f);
            
        }

        internal void SoldierDeathControl()
        {
            if (soldierHealth <= 0)
            { selfHealthBarController.DeathFx(_aiSoldierController.transform);
                Debug.LogError("Death");
                GameManager.Instance.poolManager.SetPooledObject(gameObject, 4);
                GameManager.Instance.enemyTargets.Remove( _aiSoldierController.selfTarget);
            }
        }

        internal void ResetSoldier()
        {
            soldierHealth = _maxHealth;
            selfHealthBarController.HealthUpdate(_maxHealth);
        }
    }
}

