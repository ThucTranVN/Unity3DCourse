using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Animator animator;
    private Rigidbody[] rigidBodies;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigidBodies = GetComponentsInChildren<Rigidbody>();
       
        DeactiveRagdoll();
    }

    public void DeactiveRagdoll()
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = true;
        }

        animator.enabled = true;
    }

    public void ActiveRagdoll()
    {
        foreach (var rigidBody in rigidBodies)
        {
            rigidBody.isKinematic = false;
        }

        animator.enabled = false;
    }

    public void ApplyForce(Vector3 force , Rigidbody rigidbody)
    {
        rigidbody.AddForce(force, ForceMode.VelocityChange);
    }
}
