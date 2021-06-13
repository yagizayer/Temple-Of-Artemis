using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ComplexMove : MonoBehaviour
{

    public NavMeshAgent navMeshAgent;
    public CharacterController controller;
    public Transform currentCamera;
    public Animator animator;

    public float moveSpeed = 12f, rotationSpeed = 200;
    public bool isMoveable = true;
    bool moving = false, isSprinting = false;


    float horizontal = 0, vertical = 0;

    private void Start()
    {
        if (navMeshAgent == null) navMeshAgent = GetComponent<NavMeshAgent>();
        if (controller == null) controller = GetComponent<CharacterController>();
        if (currentCamera == null) currentCamera = Camera.main.transform;
        if (animator == null) animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        MoveCharacterWithNavmesh();
    }

    void MoveCharacterWithNavmesh()
    {

        Vector3 rawMoveDir = Vector3.forward * vertical + Vector3.right * horizontal;

        Vector3 cameraForwardNormalized = Vector3.ProjectOnPlane(currentCamera.forward, Vector3.up);
        Quaternion rotationToCamNormal = Quaternion.LookRotation(cameraForwardNormalized, Vector3.up);

        Vector3 finalMoveDir = rotationToCamNormal * rawMoveDir;

        moving = false;
        if (!Vector3.Equals(finalMoveDir, Vector3.zero))
        {
            Quaternion rotationToMoveDir = Quaternion.LookRotation(finalMoveDir, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToMoveDir, rotationSpeed * Time.deltaTime);
            moving = true;
        }

        animator.SetBool("Moving", moving);
        animator.SetFloat("VerticalSpeed", vertical);

        Vector3 result = finalMoveDir * (isSprinting ? moveSpeed * 2 : moveSpeed) * Time.deltaTime;
        navMeshAgent.Move(result);
    }
    public void OnMoveInput(float horizontal, float vertical)
    {
        this.horizontal = horizontal;
        this.vertical = vertical;
    }
    public void OnSprintInput(bool sprintInput)
    {
        this.isSprinting = sprintInput;
    }


}
