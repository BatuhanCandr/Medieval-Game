using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public class EnemyMeleeAtack : EnemyCombat
    {
        internal override void Attack()
        {
            var enemyAgent = _enemyController.enemyAIController.enemyAgent;
            var closestTarget = _enemyController.enemyAIController.closestEnemyTarget;
            
            if (enemyAgent.remainingDistance <= enemyAgent.stoppingDistance)
            {
                if (closestTarget != null)
                {
                    switch (closestTarget.targetType)
                    {
                        case EnemyTarget.TargetType.player:
                            GameManager.Instance.player.GetDamage(_enemyController._enemyData.damage);
                            break;
                        case EnemyTarget.TargetType.building:
                            closestTarget.buildingHealthController.GetBuildingDamage(_enemyController._enemyData.damage);
                            closestTarget.buildingHealthController.BuildingDeathControl();
                            break;
                        case EnemyTarget.TargetType.AISoldier:
                            closestTarget.AISoldierController.AISoldierHealthController?.GetDamage(_enemyController._enemyData.damage);
                            closestTarget.AISoldierController.AISoldierHealthController?.SoldierDeathControl();
                            break;
                    }
                }
            }
        }
    }
}