using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttackPlayerState : AiState
{
    public AiStateID GetID()
    {
        return AiStateID.Attack;
    }

    public void Enter(AiAgent agent)
    {
        agent.weapons.ActivateWeapon();
        agent.weapons.SetTarget(agent.playerTransform);
        agent.navMeshAgent.stoppingDistance = 5f;
        agent.weapons.SetFiring(true);
    }

    public void Update(AiAgent agent)
    {
        if (agent.navMeshAgent.enabled)
        {
            agent.navMeshAgent.destination = agent.playerTransform.position;
        }

        if (agent.playerTransform.GetComponent<Health>().IsDead())
        {
            agent.stateMachine.ChangeState(AiStateID.Idle);
        }

        Vector3 playerDirection = agent.playerTransform.position - agent.transform.position;

        Vector3 agentDirection = agent.transform.forward;

        playerDirection.Normalize();

        float dotProduct = Vector3.Dot(playerDirection, agentDirection);

        if (dotProduct <= 0)
        {
            agent.weapons.SetFiring(false);
        }
        else
        {
            agent.weapons.SetFiring(true);
        }
    }

    public void Exit(AiAgent agent)
    {
        agent.navMeshAgent.stoppingDistance = 0f;
    }
}
