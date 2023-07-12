using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiDeathState : AiState
{
    private float dieForce;
    public Vector3 direction;
    public Rigidbody rigidbody;

    public AiStateID GetID()
    {
        return AiStateID.Death;
    }

    public void Enter(AiAgent agent)
    {
        if (DataManager.HasInstance)
        {
            dieForce = DataManager.Instance.GlobalConfig.dieForce;
        }
        agent.ragdoll.ActiveRagdoll();
        direction.y = 1f;
        agent.ragdoll.ApplyForce(direction * dieForce, rigidbody);
        agent.healthBar.Deactive();
        agent.health.DestroyWhenDeath();
    }

    public void Exit(AiAgent agent)
    {
        
    }

    public void Update(AiAgent agent)
    {
        
    }
}
