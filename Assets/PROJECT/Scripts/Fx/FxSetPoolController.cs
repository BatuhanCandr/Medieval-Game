using System;
using System.Collections;
using System.Collections.Generic;
using StolenPadCase;
using UnityEngine;

namespace StolenPadCase
{
    
}
public class FxSetPoolController : MonoBehaviour
{
    [SerializeField] private int _poolType;

    private void OnParticleSystemStopped()
    {
        GameManager.Instance.poolManager.SetPooledObject(gameObject,_poolType);
    }
}
