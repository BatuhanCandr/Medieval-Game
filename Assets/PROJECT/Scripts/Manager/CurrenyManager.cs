using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public class CurrenyManager : MonoBehaviour
    {
        [SerializeField] internal int currentCurrency;

        internal void Pay(int price)
        {
            if (currentCurrency >= price)
            {
                currentCurrency -= price;
            }
           
        }
        
    }

}
