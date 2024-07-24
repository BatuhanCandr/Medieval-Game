using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


namespace StolenPadCase
{
    internal class RoundManager : MonoBehaviour
    {
        [SerializeField] internal List<RoundData> roundDatas;
        [SerializeField] internal int currentRound;
        [SerializeField] internal DayChangerController dayChangerController;
        

        internal void NightEndChecker()
        {
            if (GameManager.Instance.isNight && GameManager.Instance._enemyControllers.Count == 1)
            {
                Debug.LogError("DAY!!");
                currentRound++;
                StartCoroutine(dayChangerController.Day());
            }
        }
    }

    [Serializable]
    internal class RoundData
    {
        public int meleeEnemyCount;
        public int rangerEnemyCount;


    }
}
