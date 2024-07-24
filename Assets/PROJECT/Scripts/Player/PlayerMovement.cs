using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace StolenPadCase
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] internal CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        [SerializeField] internal float playerSpeed = 12.0f;
        private float speedMultiplier;
        private float gravityValue = -9.81f;

      
        private bool isShiftPressed = false;
        [SerializeField] private float shiftMultiplier;
        [SerializeField] internal ParticleSystem _commandFx;
        

        void Update()
        {
            Movement();
            RunControl();
            CommandControlFx();
        }

        private void RunControl()
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                isShiftPressed = true;
            }
            else
            {
                isShiftPressed = false;
            }
        }

        internal void CommandControlFx()
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                _commandFx.Play();
            }
            else
            {
                _commandFx.Stop();
            }
        }

        private void Movement()
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // Hızı arttırma kontrolü ekle
            speedMultiplier = isShiftPressed ? shiftMultiplier : 1.0f;
            Vector3 horizontalMove = move * (Time.deltaTime * playerSpeed * speedMultiplier);
            horizontalMove.y = playerVelocity.y; // Yerçekimi etkisi devam etsin
            controller.Move(horizontalMove);

            if (move != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(move);
                GameManager.Instance.player.playerAnimationController.PlayerRunAnim();
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
            }
            else
            {
                GameManager.Instance.player.playerAnimationController.PlayerIdleAnim();
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
        }
    }
}