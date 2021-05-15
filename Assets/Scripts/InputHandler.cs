using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class MoveInputEvent : UnityEvent<float, float> { }
[Serializable]
public class SprintInputEvent : UnityEvent<bool> { }
public class InputHandler : MonoBehaviour
{
    public MoveInputEvent moveInputEvent;
    public SprintInputEvent sprintInputEvent;
    InputManager inputManager;

    private void Awake()
    {
        inputManager = new InputManager();
    }
    private void OnEnable()
    {
        inputManager.Gameplay.Enable();
        inputManager.Gameplay.Move.performed += OnMovePerformed;
        inputManager.Gameplay.Move.canceled += OnMovePerformed;
        inputManager.Gameplay.Sprint.started += OnSprintStarted;
        inputManager.Gameplay.Sprint.canceled += OnSprintStarted;
    }
    void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector3 moveInput = context.ReadValue<Vector2>();
        moveInputEvent.Invoke(moveInput.x, moveInput.y);
    }
    void OnSprintStarted(InputAction.CallbackContext context)
    {
        if (context.started)
            sprintInputEvent.Invoke(true);
        if (context.canceled)
            sprintInputEvent.Invoke(false);
    }
}
