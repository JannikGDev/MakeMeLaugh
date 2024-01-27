using System.Collections;
using System.Collections.Generic;
using PlayerControls.Scripts;
using UnityEngine;

public class Input_Player : IInput
{
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        jumpInput = Input.GetButtonDown("Jump");
        attackInput = Input.GetButtonDown("Fire1");
        testInput = Input.GetButtonDown("Submit");
    }
    
}
