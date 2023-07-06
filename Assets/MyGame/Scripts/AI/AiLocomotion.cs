using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AiLocomotion : MonoBehaviour
{
    public Transform playerTransform;
    public float maxTime = 1f;
    public float maxDistance = 1f;

    private NavMeshAgent aiAgent;
    private Animator animator;
    private float timer = 0f;

    void Start()
    {
        aiAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            float distance = (playerTransform.position - aiAgent.destination).sqrMagnitude;
            if(distance > maxDistance * maxDistance)
            {
                aiAgent.destination = playerTransform.position;
            }
            timer = maxTime;

        }
        
        animator.SetFloat("Speed", aiAgent.velocity.magnitude);
    }
}
