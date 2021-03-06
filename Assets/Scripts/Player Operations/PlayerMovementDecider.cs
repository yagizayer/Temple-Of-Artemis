using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

[RequireComponent(typeof(ComplexMove), typeof(NpcMovement))]
public partial class PlayerMovementDecider : MonoBehaviour
{
    public MovementType MyMovementType
    {
        get { return _myMovementType; }
        set
        {
            _movementTypeChanged = true;
            _myMovementType = value;
        }
    }
    ComplexMove _complexMove;
    NpcMovement _npcMovement;

    private MovementType _myMovementType = MovementType.AutoMove;
    private bool _movementTypeChanged = true;
    private bool _canBeChecked = false;

    private SoundManagement _soundManager;
    private void Start()
    {
        if (_soundManager == null) _soundManager = FindObjectOfType<SoundManagement>();
        _complexMove = GetComponent<ComplexMove>();
        _npcMovement = GetComponent<NpcMovement>();
        StartCoroutine(RotarChecking());
    }

    IEnumerator RotarChecking()
    {
        yield return new WaitForSecondsRealtime(4f);
        _canBeChecked = true;
    }

    private void FixedUpdate()
    {
        if (!_npcMovement.IsMoving && _canBeChecked)
        {
            MyMovementType = MovementType.ControlledMove;
            _canBeChecked = false;
        }
        if (MyMovementType == MovementType.AutoMove && _movementTypeChanged)
        {
            _complexMove.enabled = false;
            _npcMovement.enabled = true;
            _npcMovement.MoveNextPosition();
            _movementTypeChanged = false;
        }
        if (MyMovementType == MovementType.ControlledMove && _movementTypeChanged)
        {
            _npcMovement.GetComponent<NavMeshAgent>().ResetPath();
            _soundManager.StopSound(_soundManager.EffectSounds[EffectSound.Walking]);
            _npcMovement.enabled = false;
            _npcMovement.TargetQueue.Clear();
            _complexMove.enabled = true;
            _movementTypeChanged = false;
        }
    }
}
