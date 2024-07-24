using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    internal class EnemyTarget : MonoBehaviour
    {
        [SerializeField] internal TargetType targetType;
        internal BuildingHealthController buildingHealthController;
        internal Player player;
        internal AISoldierController AISoldierController;

        void Start()
        {
          CheckBuilding();
            GetType();
        }

        void CheckBuilding()
        {
            if (targetType != TargetType.building)
            {
                GameManager.Instance.enemyTargets.Add(this);
            }
        }

        internal void AddBuildingToList()
        {
            if (targetType == TargetType.building)
            {
                GameManager.Instance.enemyTargets.Add(this);
            }
        }
        private new void GetType()
        {
            if (targetType == TargetType.building)
            {
                buildingHealthController = GetComponent<BuildingHealthController>();
            }

            if (targetType == TargetType.player)
            {
                player = GetComponent<Player>();
            }
            
            if (targetType == TargetType.AISoldier)
            {
                AISoldierController = GetComponent<AISoldierController>();
            }
        }

        public enum TargetType
        {
            player,
            building,
            AISoldier,
        }
    }
}