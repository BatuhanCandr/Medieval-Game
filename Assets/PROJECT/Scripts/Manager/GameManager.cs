using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public class GameManager : MonoBehaviour
    {
    
        public static GameManager Instance { get; set; }


        [Header("Class Refferences")]
        [SerializeField] internal Player player;
        [SerializeField] internal CameraController cameraController;
        [SerializeField] internal TrainBuildingController trainBuildingController;
        


        [Header("Game")] 
        [SerializeField] internal Light directionalLight;
        [SerializeField] internal bool isNight;
        [SerializeField] internal List<EnemyTarget> enemyTargets;
        [SerializeField] internal List<EnemyController> _enemyControllers;
        [SerializeField] internal BuildingHealthController mainCastle;

        [Space] [Header("Managers")] 
        [SerializeField] internal PoolManager poolManager;
        [SerializeField] internal CurrenyManager currencyManager;
        [SerializeField] internal RoundManager roundManager;
        [SerializeField] internal EnemySpawnManager EnemySpawnManager;
        [SerializeField] internal UIManager UIManager;
        
        

        
        
    
        private void Awake()
        {
            Instance = this;
        }
    }  
}

