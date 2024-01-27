using System;
using System.Collections;
using System.Collections.Generic;
using PlayerControls.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class LooseLifeTest : MonoBehaviour
{
    [SerializeField] private IInput input;
    [SerializeField] private GameObject healtComponent;
    public GameObject heart;
    private void Update()
    {
        bool testButton = input.testInput;
        if (testButton)
        {
            SubstractLife();
        }
    }

    private void SubstractLife()
    {
        healtComponent.GetComponent<HealthComponent>().TakeDamage(1);
        Debug.Log("Life: " + healtComponent.GetComponent<HealthComponent>().health);
    }
}
