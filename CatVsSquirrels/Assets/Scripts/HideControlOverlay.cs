using System.Collections;
using System.Collections.Generic;
using PlayerControls.Scripts;
using UnityEngine;

public class HideControlOverlay : MonoBehaviour
{
    
    [SerializeField] private IInput _input;
    [SerializeField] private GameObject control;


    private void Update()
    {
        bool testButton = _input.testInput;
        if (testButton)
        {
            HideGameObject();
        }
    }

    private void HideGameObject()
    {
        control.SetActive(false);
    }
}
