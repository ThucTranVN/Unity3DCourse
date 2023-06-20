using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAiming : MonoBehaviour
{
    public float turnSpeed = 15;
    public Transform ignoreZone;
    public float radius;
    public bool showGizmos;

    private Camera mainCamera;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), turnSpeed * Time.fixedDeltaTime);

        Collider[] colliders = Physics.OverlapSphere(ignoreZone.position, radius);
        foreach (var collider in colliders)
        {
            if (!collider.gameObject.layer.Equals(LayerMask.NameToLayer("Ignore Raycast")))
            {
                collider.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (!showGizmos) return;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(ignoreZone.position, radius);
    }
}
