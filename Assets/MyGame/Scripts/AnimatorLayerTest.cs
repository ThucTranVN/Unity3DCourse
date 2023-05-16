using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AnimatorLayerTest : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private TextMeshProUGUI healthText;
    [SerializeField]
    private float maximumInjuredLayerWeight;
    private float maximumHealth = 100;
    private float currentHealth;
    private int injuredLayerIndex;
    private float layerWeightVelocity;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        currentHealth = maximumHealth;
        injuredLayerIndex = animator.GetLayerIndex("Injured");

        //int normalValue = 1;
        //NormalFunction(normalValue);
        //Debug.Log("Normal value: " +normalValue);

        //int refValue = 1;
        //RefFunction(ref refValue);
        //Debug.Log("Ref value: " + refValue);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth -= maximumHealth / 10;

            if(currentHealth < 0)
            {
                currentHealth = maximumHealth;
            }
        }

        healthText.text = $"Health: {currentHealth}";
        float healthPercentage = currentHealth / maximumHealth;

        float currentInjuredLayerWeight = animator.GetLayerWeight(injuredLayerIndex);

        float targetInjuredLayerWeight = (1 - healthPercentage) * maximumInjuredLayerWeight;
        animator.SetLayerWeight(injuredLayerIndex,
            Mathf.SmoothDamp(currentInjuredLayerWeight, targetInjuredLayerWeight, ref layerWeightVelocity, 0.2f));
    }


    //private void NormalFunction(int value)
    //{
    //    value = 100;
    //}

    //private void RefFunction(ref int value)
    //{
    //    value = 200;
    //}
}
