using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NpcMovement : MonoBehaviour
{

    // Editor variables
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private List<Transform> targetPoints = new List<Transform>();

    // This Script variables
    private Queue<Transform> targetQueue = new Queue<Transform>();
    private Transform currentTarget;
    private bool lastTargetVisited = false;
    private bool isMoving = false;
    private bool trigger = true;

    // Accessable variables
    public Queue<Transform> TargetQueue => targetQueue;
    public bool IsMoving => isMoving;


    private void Start()
    {
        if (navMeshAgent == null) navMeshAgent = transform.GetComponent<NavMeshAgent>();
        if (animator == null) animator = transform.GetComponent<NpcDisplay>().NpcGameObject.GetComponent<Animator>();

        if (targetPoints.Count > 0)
        {
            EnqueueTargets(targetPoints);
            currentTarget = targetQueue.Dequeue();
        }
    }

    private void FixedUpdate()
    {
        if (targetPoints.Count > 0)
            CheckMovement();
    }

    private void CheckMovement()
    {
        if (!lastTargetVisited)
        {
            if (trigger)
            {
                GoTo(currentTarget);
                trigger = false;
                if (targetQueue.Count > 0) currentTarget = targetQueue.Dequeue();
            }
        }
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }
        if (isMoving)
        {
            animator.SetBool("NPC Walking", true);
        }
        else
        {
            animator.SetBool("NPC Walking", false);
        }
    }

    private void GoTo(Transform target)
    {
        if (targetQueue.Count == 0) lastTargetVisited = true;
        navMeshAgent.destination = target.position;
        transform.rotation.SetLookRotation(Vector3.RotateTowards(transform.position, target.position, 200, 200));
    }

    private void EnqueueTargets(List<Transform> targetPoints)
    {
        foreach (Transform item in targetPoints)
        {
            targetQueue.Enqueue(item);
        }
    }

    public void MoveNextPosition()
    {
        trigger = true;
    }


}
