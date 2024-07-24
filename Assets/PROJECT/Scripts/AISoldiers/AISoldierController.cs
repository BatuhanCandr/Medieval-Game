using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

namespace StolenPadCase
{
    public class AISoldierController : MonoBehaviour
    {
        [Header("Reference Classes")]
        [SerializeField] internal NavMeshAgent soldierAgent;
        [SerializeField] internal AISoldierAnimationController selfAnimator;
        [SerializeField] internal EnemyTarget selfTarget;
        [SerializeField] internal StretchEffectController selfStretchEffectController;
        [SerializeField] internal AISoldierHealthController AISoldierHealthController;
       


        private bool isFollowing;
        private Vector3 followedPos;


        internal EnemyController closestEnemyTarget;
        private bool isInRange;


        private void Update()
        {
            FollowPlayer();
            RangeCalculateAndMove();
            LookAtTarget();
            CheckTargetReached();
        }

      

        private void LookAtTarget()
        {
            if (closestEnemyTarget != null && GameManager.Instance.isNight)
            {
                transform.LookAt(closestEnemyTarget.transform);
            }
        }

        private void FollowPlayer()
        {
            if (!GameManager.Instance.isNight)
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                   
                    soldierAgent.SetDestination(GameManager.Instance.player.transform.position);
                    selfAnimator.SoldierRunAnim();
                }

              
                if ( soldierAgent.remainingDistance <= soldierAgent.stoppingDistance)
                {
                 
                    selfAnimator.SoldierIdleAnim();
                }
                else
                {
                    selfAnimator.SoldierRunAnim();
                }
            }
            
        }

        public void RangeCalculateAndMove()
        {
            if (!isFollowing)
            {
                float closestDistanceSqr = Mathf.Infinity;
                Vector3 currentPosition = transform.position;
                var dist = Vector3.Distance(transform.position, GameManager.Instance.player.transform.position);

                foreach (EnemyController potentialTarget in GameManager.Instance._enemyControllers)
                {
                    Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                    float dSqrToTarget = directionToTarget.sqrMagnitude;
                    if (dSqrToTarget < closestDistanceSqr)
                    {
                        closestDistanceSqr = dSqrToTarget;
                        closestEnemyTarget = potentialTarget;
                    }


                    Vector3 distance = closestEnemyTarget.transform.position - currentPosition;
                    closestDistanceSqr = distance.sqrMagnitude;


                    if (closestEnemyTarget != null)
                    {
                        if (GameManager.Instance.isNight)
                        {
                            soldierAgent.SetDestination(closestEnemyTarget.transform.position);
                        }
                    }
                }
            }
        }

        void CheckTargetReached()
        {
            if (GameManager.Instance.isNight)
            {
                if (GameManager.Instance._enemyControllers.Count != 0)
                {
                    if (soldierAgent.remainingDistance <= soldierAgent.stoppingDistance)
                    {
                        isInRange = true;
                        selfAnimator.SoldierAttackAnim();
                    }
                    else
                    {
                        isInRange = false;
                        selfAnimator.SoldierRunAnim();
                    }
                }
                else if (GameManager.Instance._enemyControllers.Count == 0 || soldierAgent.remainingDistance <= soldierAgent.stoppingDistance)
                {
                    selfAnimator.SoldierIdleAnim();
                }
            }
        }
    }
}