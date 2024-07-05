using System;
using UnityEngine;

namespace Client.Scripts.Player
{
    public class PlayerAnimation : MonoBehaviour
    { 
        [SerializeField] private CharacterController characterController;
        [SerializeField] private Animator animator;

        private static readonly int Move = Animator.StringToHash("Move");

        private void Update()
        {
            animator.SetFloat(Move, characterController.velocity.magnitude, 0.1f, Time.deltaTime);
        }
    }
}