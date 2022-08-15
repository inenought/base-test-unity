using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : UpdateManager
{
    //
    Transform initialPosition;
    //
    NavMeshAgent agent;
    //
    [SerializeField] EnemyStats sts;
    //
    [SerializeField] Animator animToNavMesh;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animToNavMesh = GetComponent<Animator>();
    }

    public override void TimeUpdate()
    {
        //put code here
    }

}
