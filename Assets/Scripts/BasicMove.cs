using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basicMove : MonoBehaviour
{
    public Transform target;
    public CharacterController controller;
    public float speed = 12f;
    public Transform currentCamera;
    Vector3 velocity;
    bool isGrounded;
    bool moving = false;
    public Animator animator;

    private void Start()
    {
        if (controller == null) controller = GetComponent<CharacterController>();
        if (target == null) target = transform;
        if (currentCamera == null) currentCamera = Camera.main.transform;
        if (animator == null) animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        float horizontalInput = SimpleInput.GetAxis("Horizontal");
        float verticalInput = SimpleInput.GetAxis("Vertical");

        Vector3 move = currentCamera.right * horizontalInput + currentCamera.forward * verticalInput;
        move.y = 0;
        Vector3 moveFinal = move.normalized * speed * Time.deltaTime;
        controller.Move(moveFinal);


        makeGravity();


        if ((horizontalInput != 0) || (verticalInput != 0)) moving = true;
        if ((horizontalInput == 0) && (verticalInput == 0)) moving = false;

        animator.SetBool("Moving", moving);
        animator.SetFloat("HorizontalSpeed", horizontalInput);
        animator.SetFloat("VerticalSpeed", verticalInput);
    }
    
    void makeGravity()
    {
        isGrounded = Physics.CheckSphere(target.position, .5f);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += -9.8f * Time.deltaTime * Time.deltaTime;
        controller.Move(velocity);
    }


}
