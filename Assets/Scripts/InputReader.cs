using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour
{
    MainInput input;
    PlayerMovement playerMovement;
    [SerializeField] FollowTarget cameraFollow;
    private void Awake()
    {
        input = new MainInput();
        input.Enable();

        playerMovement = GetComponent<PlayerMovement>();
        input.Player.Move.performed += OnMovePerformed;
        input.Player.Move.canceled += OnMoveCanceled;
        input.Player.FixCamera.performed += OnFixCameraPerformed;
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        playerMovement.Move(context.ReadValue<Vector2>());
    }
    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        playerMovement.Move(Vector2.zero);
    }
    private void OnFixCameraPerformed(InputAction.CallbackContext context)
    {
        cameraFollow.FixCameraRotation();
        //playerMovement.FixCharacterForward();
    }
}
