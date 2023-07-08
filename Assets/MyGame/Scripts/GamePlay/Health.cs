using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth;
    public float blinkDuration = 0.1f;
    public float dieForce;
    private float currentHealth;
    private Ragdoll ragdoll;
    private UIHealthBar healthBar;
    private SkinnedMeshRenderer skinnedMeshRenderer;

    void Start()
    {
        currentHealth = maxHealth;
        ragdoll = GetComponent<Ragdoll>();
        healthBar = GetComponentInChildren<UIHealthBar>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        SetUp();
    }

    public void TakeDamage(float amount, Vector3 direction, Rigidbody rigidbody)
    {
        currentHealth -= amount;
        if (healthBar != null)
        {
            healthBar.SetHealthBarPercentage(currentHealth / maxHealth);
        }
        if (currentHealth <= 0f)
        {
            Die(direction, rigidbody);
        }
        StartCoroutine(EnemyFlash());
    }

    private void SetUp()
    {
        var rigidBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in rigidBodies)
        {
            HitBox hitBox = rigidbody.gameObject.AddComponent<HitBox>();
            hitBox.health = this;
            hitBox.rb = rigidbody;
        }
    }

    private IEnumerator EnemyFlash()
    {
        skinnedMeshRenderer.material.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(blinkDuration);
        skinnedMeshRenderer.material.DisableKeyword("_EMISSION");
        StopCoroutine(nameof(EnemyFlash));
    }

    private void Die(Vector3 direction , Rigidbody rigidbody)
    {
        ragdoll.ActiveRagdoll();
        direction.y = 1f;
        ragdoll.ApplyForce(direction * dieForce , rigidbody);
        healthBar.Deactive();
        Destroy(this.gameObject, 3f);
    }
}
