using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Serialization;

namespace StolenPadCase
{
    public class BuildingCreator : MonoBehaviour
    {
        
        [SerializeField] internal EnemyTarget enemyTarget;
       
        
        [SerializeField] internal int buildingPrice;
        [SerializeField] internal GameObject _mainBuilding;
        [SerializeField] private GameObject _shadowBuilding;
        [SerializeField] private GameObject _buildingBanner;
        [SerializeField] private bool _isBuildingOpen;
        [SerializeField] internal ParticleSystem createdFX;



        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Player") && !_isBuildingOpen && !GameManager.Instance.isNight)
            {
                _shadowBuilding.SetActive(true);
                if (Input.GetKey(KeyCode.Space) &&
                    GameManager.Instance.currencyManager.currentCurrency >= buildingPrice)
                {
                    CreationAnimation();
                }
            }
        }


        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _shadowBuilding.SetActive(false);
            }
        }

        private void OpenBuilding()
        {
            _isBuildingOpen = true;
            GameManager.Instance.currencyManager.Pay(buildingPrice);
            _shadowBuilding.SetActive(false);
            _buildingBanner.SetActive(false);
            _mainBuilding.SetActive(true);
        }

        private void CreationAnimation()
        {
            Renderer shadowRenderer = _shadowBuilding.GetComponent<Renderer>();

            if (shadowRenderer != null)
            {
                OpenBuilding();
                _mainBuilding.transform.DOScale(new Vector3(.8f, .8f, .8f), .4f);
                _mainBuilding.transform.DOLocalJump(Vector3.zero, 3f,1,.4f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    _mainBuilding.transform.DOPunchScale(new Vector3(0.06f, 0.06f, 0.06f), .6f).SetEase(Ease.Linear);
                    GameManager.Instance.cameraController.CameraShake();
                    createdFX.Play();
                    enemyTarget.AddBuildingToList();
                    
                    
                });
                
            }
            else
            {
                Debug.LogError("ShadowRenderer not found!");
            }
        }
        
    }
}