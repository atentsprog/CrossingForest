using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public static Player instance;
    public NavMeshAgent agent;
    Animator animator;
    private void Awake()
    {
        instance = this;
        agent = GetComponent<NavMeshAgent>();

        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (agent.remainingDistance == 0)
            animator.Play("Idle");
        else
            animator.Play("Run");
    }
}
