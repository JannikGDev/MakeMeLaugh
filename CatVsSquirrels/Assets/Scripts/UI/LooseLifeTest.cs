using System;
using System.Collections;
using System.Collections.Generic;
using PlayerControls.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class LooseLifeTest : MonoBehaviour
{
    [SerializeField] private IInput input;
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
        GameManagerHealth.Instance.health--;
        Debug.Log("Life: " + GameManagerHealth.Instance.health);
    }
}
