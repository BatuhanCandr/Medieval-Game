using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace StolenPadCase
{
    public class StretchEffectController : MonoBehaviour
    {
        private Tween stretchTween;
        private Vector3 firstScale;

        private float TintMultiplier = 5;

      [SerializeField]  private List<Renderer> _enemyMat;

      [SerializeField] private bool isCanStretch;
      [SerializeField] private bool isCanChangeColor;
      

        private void Start()
        {
            firstScale = transform.localScale;
          
        }

        internal IEnumerator ChangeColor()
        {
            
            float t = 0;
            while (t < 0.3f)
            {
                if (isCanChangeColor)
                {
                    t += Time.deltaTime;
                    float hue, saturation, value;
                    Color.RGBToHSV(Color.red, out hue, out saturation, out value);
                    value *= 0.8f;
                    Color darkRed = Color.HSVToRGB(hue, saturation, value);
        
                    // Tüm _enemyMat listesindeki renderlara renk değişimi uygula
                    foreach (Renderer renderer in _enemyMat)
                    {
                        foreach (Material material in renderer.materials)
                        {
                            material.color = Color.Lerp(darkRed * TintMultiplier, Color.white, t / 0.3f);
                        }
                    }

                    yield return null;
                }
              
            }
        }


        internal void EnemyStretch(float totalTime, float stretchSize)
        {
            if (isCanStretch)
            {
                stretchTween.Kill();
                stretchTween = transform.DOScaleY(firstScale.y * stretchSize, totalTime / 4).OnComplete(() =>
                {
                    transform.DOScaleY(firstScale.y, totalTime / 4).OnComplete(() =>
                    {
                        transform.DOScaleX(firstScale.x * stretchSize, totalTime / 4).OnComplete(() =>
                        {
                            transform.DOScaleX(firstScale.x, totalTime / 4).SetEase(Ease.Linear);
                        }).SetEase(Ease.Linear);
                    }).SetEase(Ease.Linear);
                }).SetEase(Ease.Linear);
            }
           
        }
    }
}