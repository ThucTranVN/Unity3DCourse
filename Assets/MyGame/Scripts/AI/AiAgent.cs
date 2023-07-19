using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiAgent : MonoBehaviour
{
    public AiStateID initState;
    [HideInInspector]
    public AiStateMachine stateMachine;
    [HideInInspector]
    public NavMeshAgent navMeshAgent;
    [HideInInspector]
    public Ragdoll ragdoll;
    [HideInInspector]
    public UIHealthBar healthBar;
    [HideInInspector]
    public Health health;
    [HideInInspector]
    public Transform playerTransform;
    [HideInInspector]
    public AiWeapon weapons;

    void Start()
    {
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
        navMeshAgent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        ragdoll = GetComponent<Ragdoll>();
        healthBar = GetComponentInChildren<UIHealthBar>();
        weapons = GetComponent<AiWeapon>();
        stateMachine = new AiStateMachine(this);
        stateMachine.RegisterState(new AiChasePlayerState());
        stateMachine.RegisterState(new AiDeathState());
        stateMachine.RegisterState(new AiIdleState());
        stateMachine.RegisterState(new AiFindWeaponState());
        stateMachine.RegisterState(new AiAttackPlayerState());
        stateMachine.ChangeState(initState);
    }

    void Update()
    {
        stateMachine.Update();
    }
}
