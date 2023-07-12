using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private float maxHealth;
    private float blinkDuration;
    private float currentHealth;
    private Ragdoll ragdoll;
    private UIHealthBar healthBar;
    private SkinnedMeshRenderer skinnedMeshRenderer;
    private AiAgent aiAgent;
    private float timeDestroyAI;

    void Start()
    {
        if (DataManager.HasInstance)
        {
            maxHealth = DataManager.Instance.GlobalConfig.maxHealth;
            blinkDuration = DataManager.Instance.GlobalConfig.blinkDuration;
            timeDestroyAI = DataManager.Instance.GlobalConfig.timeDestroyAI;
        }
        currentHealth = maxHealth;
        ragdoll = GetComponent<Ragdoll>();
        healthBar = GetComponentInChildren<UIHealthBar>();
        aiAgent = GetComponent<AiAgent>();
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
        AiDeathState deathState = aiAgent.stateMachine.GetState(AiStateID.Death) as AiDeathState;
        deathState.direction = direction;
        deathState.rigidbody = rigidbody;
        aiAgent.stateMachine.ChangeState(AiStateID.Death);
    }

    public void DestroyWhenDeath()
    {
        Destroy(this.gameObject, timeDestroyAI);
    }
}
