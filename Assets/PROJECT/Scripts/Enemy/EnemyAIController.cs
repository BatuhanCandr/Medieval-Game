using System;
using System.Collections;
using System.Collections.Generic;
using StolenPadCase;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIController : MonoBehaviour
{
    [SerializeField] internal EnemyController selfEnemyController;
    [SerializeField] internal NavMeshAgent enemyAgent;

    internal EnemyTarget closestEnemyTarget;
    private bool isInRange;

    private void Update()
    {
        LookAtTarget();
        RangeCalculateAndMove();
    }

    private void LookAtTarget()
    {
        if (closestEnemyTarget != null && selfEnemyController._enemyData.health > 0)
        {
            transform.LookAt(closestEnemyTarget.transform);
        }
    }

    public void RangeCalculateAndMove()
    {
        float closestDistanceSqr = selfEnemyController._enemyData.range;
        Vector3 currentPosition = transform.position;

        foreach (EnemyTarget potentialTarget in GameManager.Instance.enemyTargets)
        {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;

            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                closestEnemyTarget = potentialTarget;
            }
        }


        if (closestDistanceSqr < selfEnemyController._enemyData.range)
        {
            enemyAgent.SetDestination(closestEnemyTarget.transform.position);
        }
        else if (closestDistanceSqr > selfEnemyController._enemyData.range)
        {
            closestEnemyTarget = null;
        }
       

        CheckTargetReached();
    }

    void CheckTargetReached()
    {
        if (enemyAgent.remainingDistance <= enemyAgent.stoppingDistance)
        {
            isInRange = true;
            selfEnemyController._enAnimationController.EnemyAttackAnim();
        }
        else
        {
            isInRange = false;
            selfEnemyController._enAnimationController.EnemyRunAnim();
        }
    }
}