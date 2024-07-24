using System;
using System.Collections;
using UnityEngine;

namespace StolenPadCase
{
    public class BowAttackController : MonoBehaviour
    {
        [SerializeField] internal EnemyController closestEnemy;
        [SerializeField] private Transform _arrowSpawnPos;
        [SerializeField] private bool _canAttack;


        private bool _canShoot = false;
        public float shootInterval;
        private float _shootTimer = 0f;

        private void Start()
        {
            shootInterval = GameManager.Instance.player.playerData.attackSpeed;
        }

        private void Update()
        {
            RangeCalculate();
            ShootTimer();
        }

        private void ShootTimer()
        {
            if (_canShoot && _shootTimer <= 0f && GameManager.Instance._enemyControllers.Count != 0)
            {
                Shoot();

                _shootTimer = shootInterval;
            }

            _shootTimer -= Time.deltaTime;
        }

        private void Shoot()
        {
            if (closestEnemy != null && _canAttack)
            {
                GameObject arrow = GameManager.Instance.poolManager.GetPooledObject(ObjectType.arrow);
                arrow.transform.position = _arrowSpawnPos.position;
            }
        }


        private void RangeCalculate()
        {
            float closestDistanceSqr = Mathf.Infinity;
            Vector3 currentPosition = transform.position;

            foreach (EnemyController potentialTarget in GameManager.Instance._enemyControllers)
            {
                Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
                float dSqrToTarget = directionToTarget.sqrMagnitude;
                if (dSqrToTarget < closestDistanceSqr)
                {
                    closestDistanceSqr = dSqrToTarget;
                    closestEnemy = potentialTarget;
                }

                Vector3 distance = closestEnemy.transform.position - currentPosition;
                closestDistanceSqr = distance.sqrMagnitude;


                if (closestDistanceSqr <= 300)
                {
                    _canShoot = true;
                }
                else
                {
                    _canShoot = false;
                }
            }
        }
    }
}