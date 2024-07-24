using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using StolenPadCase;
using UnityEngine;

namespace StolenPadCase
{
    internal class EnemyRangeAttack : EnemyCombat
    {
        [SerializeField] private Transform spawnPos;
        internal override void Attack()
        {
            GameObject fireBall = GameManager.Instance.poolManager.GetPooledObject(ObjectType.fireBall);
            fireBall.transform.position = spawnPos.position;
            fireBall.GetComponent<FireBallController>().enemyController = _enemyController;
        }

       
    }

}
