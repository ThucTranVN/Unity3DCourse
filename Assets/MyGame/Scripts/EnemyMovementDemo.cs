using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovementDemo : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent enemyAI;

    private void Awake()
    {
        enemyAI = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if(!enemyAI.pathPending && enemyAI.remainingDistance < 0.5f)
        {
            GoToNextPoint();
        }

        //enemyAI.SetDestination(player.position);
    }

    private void GoToNextPoint()
    {
        if(points.Length == 0)
        {
            return;
        }

        enemyAI.destination = points[destPoint].position;
        destPoint = (destPoint + 1) % points.Length;
    }
}
