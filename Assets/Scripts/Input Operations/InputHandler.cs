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
[Serializable]
public class InteractionInputEvent : UnityEvent<float, float> { }
public class InputHandler : MonoBehaviour
{
    public MoveInputEvent moveInputEvent;
    public InteractionInputEvent interactionInputEvent;
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
        inputManager.Gameplay.Interact.performed += OnInteractionPerformed;


        // TODO : close this on build
        inputManager.Gameplay.Sandbox.performed += Sandbox;
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
    void OnInteractionPerformed(InputAction.CallbackContext context)
    {
        Vector3 cursorPos = context.ReadValue<Vector2>();
        interactionInputEvent.Invoke(cursorPos.x, cursorPos.y);
    }

    void Sandbox(InputAction.CallbackContext context)
    {
        DialogManagement DM = FindObjectOfType<DialogManagement>();

        string absouluteNextLine = DM.Storyline[PhaseNames.EarlyPhase].Quests[QuestNames.Tutorial].CurrentConvarsation.NextLine;
        if (absouluteNextLine == null) absouluteNextLine = DM.Storyline[PhaseNames.EarlyPhase].Quests[QuestNames.Tutorial].NextConversation?.NextLine;

        Debug.Log(absouluteNextLine);
    }
}
