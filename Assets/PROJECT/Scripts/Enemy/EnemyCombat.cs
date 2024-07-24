using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public  abstract class EnemyCombat : MonoBehaviour
    {
      [SerializeField]  internal EnemyController _enemyController;
      internal abstract void Attack();
    }

}
