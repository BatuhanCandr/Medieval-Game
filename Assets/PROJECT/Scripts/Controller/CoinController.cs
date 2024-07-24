using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace StolenPadCase
{
    public class CoinController : MonoBehaviour
    {
        private bool canGo;
        private void Start()
        {
            GoToUp();
        }

        private void Update()
        {
            GoToPlayer();
        }

        private void GoToUp()
        {
            transform.DOLocalMoveY(transform.localPosition.y + 4, 1f).OnComplete(() =>
            {
                canGo = true;
            });


            transform.DOLocalRotate(new Vector3(0, 360, 0), 1f, RotateMode.LocalAxisAdd).SetEase(Ease.Linear)
                .SetLoops(-1, LoopType.Incremental);
        }

        private void GoToPlayer()
        {
            if (canGo)
            {
                var target = GameManager.Instance.player.transform.position;
                target.y += 2;
                transform.position = Vector3.MoveTowards(transform.position,target,35*Time.deltaTime);
            }
           
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                GameManager.Instance.currencyManager.currentCurrency += 1;
                GameManager.Instance.poolManager.SetPooledObject(gameObject, 5);
            }
        }
    }
}