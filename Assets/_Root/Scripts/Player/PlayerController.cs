using System;
using Infrastructure;
using Unity.Cinemachine;
using UnityEngine;

namespace _Root.Scripts.Player
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera povCamera;
        private CharacterController controller;
        private Vector3 playerVelocity;
        private bool groundedPlayer;
        private float playerSpeed = 2.0f;
        private float jumpHeight = 1.0f;
        private float gravityValue = -9.81f;
        
        private InputService inputService;

        private void Start()
        {
            controller = gameObject.GetComponent<CharacterController>();
            inputService = new InputService();
            inputService.Enable();
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void OnDestroy()
        {
            inputService.Disable();
        }

        void Update()
        {
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            float rotationY = povCamera.transform.eulerAngles.y;
            gameObject.transform.rotation = Quaternion.Euler(0.0f, rotationY, 0.0f);
            
            Vector2 moveInput = inputService.Input.Player.Move.ReadValue<Vector2>();
            Vector3 movement = ((transform.right * moveInput.x) + (transform.forward * moveInput.y)) * playerSpeed;
            
            controller.Move(movement * Time.deltaTime);

            CheckJump();
        }

        private void CheckJump()
        {
            // Makes the player jump
            if (inputService.Input.Player.Jump.triggered && groundedPlayer)
            {
                playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
            }

            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
    }
}