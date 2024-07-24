using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace StolenPadCase
{
    public class TrainBuildingController : MonoBehaviour
    {
        
        
        [SerializeField] internal Transform AISoldierSpawnPos;
        [SerializeField] internal int spawnCount;
        [SerializeField] internal List<AISoldierHealthController> soldierList;
        

        public void SpawnSoldiers()
        {
            for (int i = 0; i < spawnCount; i++)
            {
                var soldiers = GameManager.Instance.poolManager.GetPooledObject(ObjectType.AISoldier);

                if (soldiers != null)
                {
                    Vector3 randomPointInSphere = Random.insideUnitSphere;


                    randomPointInSphere *= 1.5f;


                    Vector3 spawnPosition = AISoldierSpawnPos.TransformPoint(randomPointInSphere);


                    soldiers.transform.position = spawnPosition;
                  //  Destroy(GameManager.Instance.UIManager.trainingBtn);
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            GameManager.Instance.UIManager.OpenTrainingBtn();
        }
        private void OnTriggerExit(Collider other)
        {
           // GameManager.Instance.UIManager.CloseTrainingBtn();
        }
        
    }
}