using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    internal class EnemyAnimationController : MonoBehaviour
    {
        
        static readonly string isAttacking = "isAttacking";
        static readonly string enDead = "isDead";
        [SerializeField] private Animator _enemyAnim;

        private void Start()
        {
            EnemyRunAnim();
        }

        internal void EnemyAttackAnim()
        {
            _enemyAnim.SetBool(isAttacking,true);
        }

        internal void EnemyRunAnim()
        {
            _enemyAnim.SetBool(isAttacking,false);
        }

        internal void EnemyDieAnim()
        {
            _enemyAnim.SetTrigger(enDead);
        }
        
    }   
}

