using System.Collections;
using UnityEngine;

namespace StolenPadCase
{
    public class HealthBarController : MonoBehaviour
    {
        [SerializeField] private MicroBar _microlight;
        private Camera mainCamera;
        private Coroutine visibilityCoroutine;

        private void Start()
        {
            GetCamera();
        }

        private void LateUpdate()
        {
            LookAtCamera();
        }

        private void GetCamera()
        {
            mainCamera = Camera.main;
        }

        private void LookAtCamera()
        {
            transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward,
                mainCamera.transform.rotation * Vector3.up);
        }

        internal void InitializeBar(int maxValue)
        {
            _microlight.Initialize(maxValue);
        }

        internal void HealthUpdate(int updateValue)
        {
            _microlight.UpdateHealthBar(updateValue);
            ShowForDuration(3);
        }

        
        public void ShowForDuration(float duration)
        {
            if (visibilityCoroutine != null)
                StopCoroutine(visibilityCoroutine);

            transform.localScale = Vector3.one;
            
            visibilityCoroutine = StartCoroutine(DisableAfterDelay(duration));
        }

     
        private IEnumerator DisableAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            transform.localScale = Vector3.zero;
        }

        internal void DeathFx(Transform transforms)
        {
            GameObject deathFx =  GameManager.Instance.poolManager.GetPooledObject(ObjectType.deathFX);
            deathFx.transform.position = transforms.position;
        }
    }
}