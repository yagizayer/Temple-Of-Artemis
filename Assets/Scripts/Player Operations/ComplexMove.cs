using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class ComplexMove : MonoBehaviour
{

    public CharacterController controller;
    public Transform currentCamera;
    public Animator animator;

    public float moveSpeed = 12f, rotationSpeed = 200;
    bool isGrounded, moving = false, isSprinting = false;


    float horizontal = 0, vertical = 0;
    Vector3 gravityForce;

    private void Start()
    {
        if (controller == null) controller = GetComponent<CharacterController>();
        if (currentCamera == null) currentCamera = Camera.main.transform;
        if (animator == null) animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        MoveCharacter();
        MakeGravity();
    }

    void MoveCharacter(){
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

        Debug.Log(finalMoveDir * (isSprinting ? moveSpeed * 2 : moveSpeed) * Time.deltaTime);

        GetComponent<NavMeshAgent>().Move(finalMoveDir * (isSprinting ? moveSpeed * 2 : moveSpeed) * Time.deltaTime * 100);
        // controller.Move(finalMoveDir * (isSprinting ? moveSpeed * 2 : moveSpeed) * Time.deltaTime);
    }
    void MakeGravity()
    {
        isGrounded = Physics.CheckSphere(transform.position, .5f);
        if (isGrounded && gravityForce.y < 0)
        {
            gravityForce.y = -2f;
        }
        gravityForce.y += -9.8f * Time.deltaTime * Time.deltaTime;
        controller.Move(gravityForce);
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
