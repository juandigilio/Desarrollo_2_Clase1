using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace Movement
{
    public class InputReader : MonoBehaviour
    {
        public CharacterMovement characterMovement;

        public void Awake()
        {
            if (characterMovement == null)
            {
                Debug.LogError($"{name} : {nameof(characterMovement)} is null");
                enabled = false;
            }
        }
       
        public void HandleMoveInput(CallbackContext context)
        {
            Vector2 moveInput = context.ReadValue<Vector2>();

            if (characterMovement != null)
            {
                Vector3 fixedMovement = new Vector3(moveInput.x, 0.0f, moveInput.y);

                characterMovement.Move(fixedMovement);
            }
        }
    }
}