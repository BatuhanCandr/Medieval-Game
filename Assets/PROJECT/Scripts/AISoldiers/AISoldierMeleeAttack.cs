using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public class AISoldierMeleeAttack : AISoldierCombat
    {
        internal override void Attack()
        {
           AISoldierController.closestEnemyTarget.enemyAIController.selfEnemyController.selfHealthControl.GetDamage(50);
           AISoldierController.closestEnemyTarget.selfHealthControl.DeathControl();
           
        }
    }

}
