using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace StolenPadCase
{
    public class FireBallController : MonoBehaviour
    {
        [SerializeField] internal EnemyController enemyController;
        private Vector3 target;

        private void Update()
        {
            FireBallShoot();
        }

        private void OnTriggerEnter(Collider other)
        {
            CheckType(other);
        }

        private void CheckType(Collider other)
        {
            var enemyTargetType = other.GetComponent<EnemyTarget>();

            if (enemyController == null || enemyTargetType == null)
                return;

            switch (enemyTargetType.targetType)
            {
                case EnemyTarget.TargetType.player:
                    GameManager.Instance.player.GetDamage(enemyController._enemyData.damage);
                    break;
                case EnemyTarget.TargetType.building:
                    enemyController.enemyAIController.closestEnemyTarget.buildingHealthController?.GetBuildingDamage(
                        enemyController._enemyData.damage);
                    enemyController.enemyAIController.closestEnemyTarget.buildingHealthController
                        ?.BuildingDeathControl();
                    break;
                case EnemyTarget.TargetType.AISoldier:
                    enemyController.enemyAIController.closestEnemyTarget.AISoldierController.AISoldierHealthController
                        ?.GetDamage(
                            enemyController._enemyData.damage);
                    enemyController.enemyAIController.closestEnemyTarget.AISoldierController.AISoldierHealthController
                        ?.SoldierDeathControl();
                    break;
            }

            GetNovaBlast();

            GameManager.Instance.poolManager.SetPooledObject(gameObject, 3);
        }

        private void GetNovaBlast()
        {
            GameObject novablast = GameManager.Instance.poolManager.GetPooledObject(ObjectType.novaBlast);
            novablast.transform.position = transform.position;
        }

        private void FireBallShoot()
        {
            if (enemyController != null)
            {
                target = enemyController.enemyAIController.closestEnemyTarget.transform.position;
                target.y += 1.5f;
                transform.DOMove(target, .7f).SetEase(Ease.Linear);
            }
        }
    }
}