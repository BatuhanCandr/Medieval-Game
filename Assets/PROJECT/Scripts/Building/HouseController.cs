using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public class HouseController : MonoBehaviour
    {
        private GameObject coin;

        private void Start()
        {
            GameManager.Instance.roundManager.dayChangerController._houseControllers.Add(this);
        }

        internal void SpawnCoin()
        {
            coin = GameManager.Instance.poolManager.GetPooledObject(ObjectType.coin);
            coin.transform.position = transform.position;
        }
        
    }
}

