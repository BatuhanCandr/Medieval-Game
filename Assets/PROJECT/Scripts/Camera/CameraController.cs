using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace StolenPadCase
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;
        [SerializeField] private float lerpTime;
        [SerializeField] private Transform camera;

        private Vector3 offset;

        private void Start()
        {
            SetCameraAngle();
        }

        private void SetCameraAngle()
        {
            camera.eulerAngles = Vector3.zero;
            offset = transform.position - playerTransform.transform.position;
           // camera.position = new Vector3(0, 0, 0);
        }

        private void LateUpdate()
        {
            CameraFollow();
        }

        private void CameraFollow()
        {
            Vector3 newPos = Vector3.Lerp(transform.position, playerTransform.position + offset,
                lerpTime * Time.deltaTime);
            transform.position = newPos;
            transform.LookAt(playerTransform);
        }

        internal void CameraShake()
        {
            camera.DOShakePosition(.3f, 0.35f, 10, 90f, false);
        }
    }
}