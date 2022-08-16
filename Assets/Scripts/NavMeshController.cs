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
    [SerializeField] EnemyStatus sts;
    //
    [SerializeField] Animator animToNavMesh;
    //
    [SerializeField] GameObject MainTarget;
    //
    [SerializeField]float minDistanceToFollow;
    [SerializeField]float maxDistanceToFollow;
    //
    [Tooltip("CHECK IF THE AGENT HAS TO FOLLOW MAINTARGET")]
    [SerializeField]bool HastoFollow = false;
    [Tooltip("CHECK IF THE TARGET HAS BEEN FINDED")]//I DID-N´T HAVE TIME TO FINISH THIS, I´LL EAT SOMETHING
    [SerializeField]bool detectedTarget = false;
    //
    [SerializeField]Transform[] Points;
    //
    int currentDestPoint;
    //
    [SerializeField]float currentTime;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animToNavMesh = GetComponent<Animator>();
    }
    public override void FrameUpdate()
    {
        currentTime += Time.deltaTime;
        if (!agent.pathPending && agent.remainingDistance < 0.5f && !detectedTarget) Patrol();
    }
    void ResetTimer()
    {
        //time to reset
        currentTime -= 0;
    }

    public override void TimeUpdate()
    {
        if (detectedTarget && HastoFollow)
        {
            if (Vector3.Distance(transform.position, MainTarget.transform.position) > minDistanceToFollow)
            {
                FindTarget(MainTarget.transform);
            }
            else if (Vector3.Distance(transform.position, MainTarget.transform.position) > maxDistanceToFollow)
            {
               BackToOrigin();
            }
        }else if (detectedTarget && !HastoFollow && agent.remainingDistance < 0.5f) { EscapeToFar();}

        animToNavMesh.SetFloat("MoveSpeed", agent.speed);
    }

    void FindTarget(Transform target)
    {
        //CHASE
        agent.SetDestination(target.position);
    }

    void BackToOrigin()
    {
        agent.SetDestination(initialPosition.position);
    }

    void EscapeToFar()
    {
        for (int i = 0; i < Points.Length; i++)
        { for (int j = 1; j < Points.Length; j++)
            { if (Vector3.Distance(transform.position, Points[i].position) > Vector3.Distance(transform.position, Points[j].position))
                { agent.SetDestination(Points[i].position);} } 
        }
    }

    void Patrol()
    {
        if (Points.Length == 0)
            return;

        agent.destination = Points[currentDestPoint].position;

        currentDestPoint = (currentDestPoint + 1) % Points.Length;
    }

}
