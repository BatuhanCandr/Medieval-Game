using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace StolenPadCase
{
    internal class UIManager : MonoBehaviour
    {
        [Header("UI elements")] [SerializeField]
        internal TextMeshProUGUI dayTimerTxt;

       [SerializeField] internal GameObject infoBanner;

        [SerializeField] internal GameObject trainingBtn;

        internal void OpenTrainingBtn()
        {
            if (trainingBtn != null)
            {
                trainingBtn.SetActive(true);
            }
        }
        
        internal void CloseTrainingBtn()
        {
            if (trainingBtn != null)
            {
                trainingBtn.SetActive(false);
            }
        }
    }
}