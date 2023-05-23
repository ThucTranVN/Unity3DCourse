using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Zombie : MonoBehaviour
{
    private enum ZombieState
    {
        Walking,
        Ragdoll
    }

    [SerializeField]
    private Camera mainCamera;
    private Rigidbody[] ragdollRigidbodies;
    private ZombieState currentState = ZombieState.Walking;
    private Animator animator;
    private CharacterController characterController;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        ragdollRigidbodies = GetComponentsInChildren<Rigidbody>();
        DisableRagdoll();
    }

    void Update()
    {
        switch (currentState)
        {
            case ZombieState.Walking:
                WalkingBehaviour();
                break;
            case ZombieState.Ragdoll:
                RagdollBehaviour();
                break;
        }
    }

    public void TriggerRagdoll(Vector3 force, Vector3 hitPoint)
    {
        EnableRagdoll();
        //Rigidbody hitRigidBody = ragdollRigidbodies.OrderBy(rigidbody => Vector3.Distance(rigidbody.position, hitPoint)).First();
        Rigidbody hitRigidBody = FindClosesHitRigidbody(hitPoint);
        hitRigidBody.AddForceAtPosition(force, hitPoint, ForceMode.Impulse);
        currentState = ZombieState.Ragdoll;
    }

    private Rigidbody FindClosesHitRigidbody(Vector3 hitPoint)
    {
        Rigidbody closestRigibody = null;
        float closestDistance = 0;

        foreach (var rigidbody in ragdollRigidbodies)
        {
            float distance = Vector3.Distance(rigidbody.position, hitPoint);
            if(closestRigibody == null || distance < closestDistance)
            {
                closestDistance = distance;
                closestRigibody = rigidbody;
            }
        }

        return closestRigibody;
    }

    private void DisableRagdoll()
    {
        foreach (var rb in ragdollRigidbodies)
        {
            rb.isKinematic = true;
        }

        animator.enabled = true;
        characterController.enabled = true;
    }

    private void EnableRagdoll()
    {
        foreach (var rb in ragdollRigidbodies)
        {
            rb.isKinematic = false;
        }

        animator.enabled = false;
        characterController.enabled = false;
    }

    private void WalkingBehaviour()
    {
        Vector3 direction = mainCamera.transform.position - transform.position;
        direction.y = 0;
        direction.Normalize();

        Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 20 * Time.deltaTime);
    }

    private void RagdollBehaviour()
    {

    }
}
