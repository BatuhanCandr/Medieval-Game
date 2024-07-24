using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace StolenPadCase
{
    public class BuildingHealthController : MonoBehaviour
    {
        [SerializeField] internal int buildingHealth;
        [SerializeField] internal HealthBarController selfHeartBarController;
        [SerializeField] internal BuildingCreator selfBuilding;

        [SerializeField] private ParticleSystem _destroyFx;
        [SerializeField] private StretchEffectController _stretchEffect;
        
        

        private void Start()
        {
            selfHeartBarController.InitializeBar(buildingHealth);
        }

        internal void GetBuildingDamage(int damage)
        {
            buildingHealth -= damage;
            _stretchEffect.EnemyStretch(.35f,1.01f);
            selfHeartBarController.HealthUpdate(buildingHealth);
        }

        internal void BuildingDeathControl()
        {
            if (buildingHealth <= 0)
            {
                
                GameManager.Instance.enemyTargets.Remove(selfBuilding.enemyTarget);
                _destroyFx.Play();
                selfBuilding._mainBuilding.SetActive(false);
            }
        }

        
    }
}

