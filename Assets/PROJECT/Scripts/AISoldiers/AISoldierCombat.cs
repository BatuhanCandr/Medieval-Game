using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public abstract class AISoldierCombat : MonoBehaviour
    {
        [SerializeField]  internal AISoldierController AISoldierController;
        internal abstract void Attack();
    }

}
