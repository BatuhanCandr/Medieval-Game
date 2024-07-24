using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public class AISoldierAnimationController : MonoBehaviour
    {
        static readonly string isAttacking = "isAttacking";
        static readonly string idle = "isWaiting";
        static readonly string enDead = "isDead";
        [SerializeField] internal Animator _soldierAnim;

   

        internal void SoldierAttackAnim()
        {
          
            _soldierAnim.SetBool(isAttacking, true);
        }

        internal void SoldierRunAnim()
        {
            _soldierAnim.SetBool(idle, false);
            _soldierAnim.SetBool(isAttacking, false);
        }

        internal void SoldierIdleAnim()
        {
            _soldierAnim.SetBool(idle, true);
            
        }
    }
}