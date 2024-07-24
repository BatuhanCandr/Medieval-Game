using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace StolenPadCase
{
    public class ArrowController : MonoBehaviour
    {
        [SerializeField] internal EnemyController target;
        [SerializeField] internal Rigidbody arrowRb;
        [SerializeField] internal bool yLook;
        [SerializeField] internal int arrowSpeed;

        private bool isHit;


        internal ParticleSystem arrowFx;


        private void Start()
        {
            GetTarget();
            Shoot();
        }

        private void Update()
        {
            ArrowRotation();
        }

        private void GetTarget()
        {
            target = GameManager.Instance.player.bowAttackController.closestEnemy;
        }

        private void Shoot()
        {
            Vector3 targetPosition = target.transform.position;
            targetPosition.y -= .5f;
            transform.DOJump(targetPosition, 3f, 1, .45f).SetEase(Ease.Linear);
        }

        void ArrowRotation()
        {
            if (target != null)
            {
                var lookPos = target.transform.position - transform.position;
                if (yLook)
                {
                    lookPos.y += 3;
                }

                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = rotation;
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                isHit = true;
                
                target.selfHealthControl.GetDamage(GameManager.Instance.player.playerData.damage);
                target.selfHealthControl.DeathControl();
                GameManager.Instance.poolManager.SetPooledObject(gameObject, 2);
            }
        }
        
    }
}