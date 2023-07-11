using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiChasePlayerState : AiState
{
    public Transform playerTransform;
    private float timer = 0f;
    private float maxDistance;
    private float maxTime;

    public AiStateID GetID()
    {
        return AiStateID.ChasePlayer;
    }

    public void Enter(AiAgent agent)
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (DataManager.HasInstance)
        {
            maxDistance = DataManager.Instance.globalConfig.maxDistance;
            maxTime = DataManager.Instance.globalConfig.maxTime;
        }
    }

    public void Update(AiAgent agent)
    {
        if (!agent.navMeshAgent.enabled)
        {
            return;
        }

        timer -= Time.deltaTime;

        if (!agent.navMeshAgent.hasPath)
        {
            agent.navMeshAgent.destination = playerTransform.position;
        }

        if (timer < 0f)
        {
            Vector3 direction = playerTransform.position - agent.navMeshAgent.destination;
            direction.y = 0;
            if (direction.sqrMagnitude > maxDistance * maxDistance)
            {
                if (agent.navMeshAgent.pathStatus != NavMeshPathStatus.PathPartial)
                {
                    agent.navMeshAgent.destination = playerTransform.position;
                }
            }
            timer = maxTime;
        }
    }

    public void Exit(AiAgent agent)
    {
        
    }
}
