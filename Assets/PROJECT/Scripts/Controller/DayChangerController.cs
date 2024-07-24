using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace StolenPadCase
{
    public class DayChangerController : MonoBehaviour
    {
        [SerializeField] internal List<HouseController> _houseControllers;
        [SerializeField] internal float holdTimeThreshold = 3f;
        private bool isSpacePressed = false;
        private bool isSpawned = false;
        private float spacePressTimer = 0f;


        private void Update()
        {
            ToTheNight();
        }

        private void ToTheNight()
        {
            if (Input.GetKeyDown(KeyCode.N) && !isSpawned)
            {
                isSpacePressed = true;
                spacePressTimer = 0f;
            }
            else if (Input.GetKeyUp(KeyCode.N))
            {
                if (isSpacePressed) 
                {
                    spacePressTimer = 0f;
                }

                if (!GameManager.Instance.isNight)
                {
                    GameManager.Instance.UIManager.dayTimerTxt.text = "DAY";
                }

                isSpacePressed = false; 
            }

            if (isSpacePressed)
            {
                spacePressTimer += Time.deltaTime;

               
                if (spacePressTimer >= holdTimeThreshold && !isSpawned)
                {
                    isSpawned = true;
                    StartCoroutine(CallMethodRoutine());
                }
            }


            UpdateTimerText(isSpacePressed);
        }

        private IEnumerator CallMethodRoutine()
        {
            yield return new WaitForSeconds(holdTimeThreshold);
            GameManager.Instance.EnemySpawnManager.SpawnEnemies();
        }

        private void UpdateTimerText(bool show)
        {
            if (show)
            {
                float remainingTime = Mathf.Clamp(holdTimeThreshold - spacePressTimer, 0f, holdTimeThreshold);
                if (remainingTime > 0f && !isSpawned)
                {
                    GameManager.Instance.UIManager.dayTimerTxt.text = "Night in " + remainingTime.ToString("F2");
                }
                else
                {
                    Night();
                }
            }
        }

        private void Night()
        {
            GameManager.Instance.UIManager.infoBanner.SetActive(false);
            GameManager.Instance.UIManager.dayTimerTxt.text = "SURVIVE";
            GameManager.Instance.isNight = true;
            DOTween.To(() => GameManager.Instance.directionalLight.intensity,
                x => GameManager.Instance.directionalLight.intensity = x, 0f, holdTimeThreshold);
        }

        internal IEnumerator Day()
        {

            GameManager.Instance.UIManager.dayTimerTxt.text = "DAY";
            GameManager.Instance.isNight = false;
            isSpawned = false;
             GameManager.Instance.UIManager.infoBanner.SetActive(true);
            GameManager.Instance.EnemySpawnManager.spawnFx.Stop();
            yield return new WaitForSeconds(1.5f);
            DOTween.To(() => GameManager.Instance.directionalLight.intensity,
                x => GameManager.Instance.directionalLight.intensity = x, 1f, holdTimeThreshold).OnComplete(() =>
            {
                GetCoin();
                ResetSoldier();
            });
        }

        private void ResetSoldier()
        {
            var soldierList = GameManager.Instance.trainBuildingController.soldierList;
            if (soldierList.Count > 0)
            {
                for (int i = 0; i < soldierList.Count; i++)
                {
                    soldierList[i].ResetSoldier();
                }
            }
        }

        private void GetCoin()
        {
            for (int i = 0; i < _houseControllers.Count; i++)
            {
                _houseControllers[i].SpawnCoin();
            }
        }
    }
}