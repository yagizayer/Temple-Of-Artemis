using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        _complexMove = GetComponent<ComplexMove>();
        _npcMovement = GetComponent<NpcMovement>();
        StartCoroutine(RotarChecking());
    }

    IEnumerator RotarChecking(){
        yield return new WaitForSecondsRealtime(4f);
        _canBeChecked = true;
    }

    private void FixedUpdate()
    {
        // TODO : BURDA KALDIN. NpcMovement kapalı olmasına rağmen belirlenmiş hedefe gidiyor
        //                      her fixedupdate call'ında 41. satır çalışıyor

        if (!_npcMovement.IsMoving && _canBeChecked) MyMovementType = MovementType.ControlledMove;
        if (MyMovementType == MovementType.AutoMove && _movementTypeChanged)
        {
            _complexMove.enabled = false;
            _npcMovement.enabled = true;
            _npcMovement.MoveNextPosition();
            _movementTypeChanged = false;
        }
        if (MyMovementType == MovementType.ControlledMove && _movementTypeChanged)
        {
            Debug.Log(_movementTypeChanged);
            _npcMovement.enabled = false;
            _complexMove.enabled = true;
            _movementTypeChanged = false;

        }
    }
}
