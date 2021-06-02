using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public static Player instance;
    public NavMeshAgent agent;
    private void Awake()
    {
        instance = this;
        agent = GetComponent<NavMeshAgent>();
    }
}
