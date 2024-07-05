using System;
using Client.Scripts.Infrustructure;
using Client.Scripts.Services.Input;
using UnityEngine;

namespace Client.Scripts.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float movementSpeed;
        
        private IInputService inputService;
        private Camera mainCamera;

        private void Awake()
        {
            inputService = Game.InputService;
        }

        private void Start()
        {
            mainCamera = Camera.main;
            mainCamera.GetComponent<CameraFollow>().Follow(gameObject);
        }

        private void Update()
        {
            Vector3 movementVector = Vector3.zero;

            if (inputService.Axis.sqrMagnitude > Constants.Epsilon)
            {
                movementVector = mainCamera.transform.TransformDirection(inputService.Axis);
                movementVector.y = 0;
                movementVector.Normalize();

                transform.forward = movementVector;
            }

            movementVector += Physics.gravity;
                
            characterController.Move(movementSpeed * movementVector * Time.deltaTime);
        }
    }
}
