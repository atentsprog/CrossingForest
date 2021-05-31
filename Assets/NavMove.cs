using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMove : MonoBehaviour
{
    public NavMeshAgent agent;

    public int myInt = -1;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    public LayerMask layer;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitData, 1000, layer))
            {
                agent.destination = hitData.point;
            }
        }
    }
}
