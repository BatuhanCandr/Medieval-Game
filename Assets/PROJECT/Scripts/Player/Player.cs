using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace StolenPadCase
{
    public class Player : MonoBehaviour
    {
        [SerializeField] internal PlayerData playerData;
        
        [SerializeField] internal PlayerMovement playerMovement;
        [SerializeField] internal PlayerAnimationController playerAnimationController;
        [SerializeField] internal BowAttackController bowAttackController;

        internal void GetDamage(int damage)
        {
            playerData.health -= damage;
        }
    }
}