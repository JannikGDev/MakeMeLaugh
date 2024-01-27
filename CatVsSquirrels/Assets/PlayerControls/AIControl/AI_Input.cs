using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using PlayerControls.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class AI_Input : IInput
{
    private GameObject Player;
    [SerializeField] private LedgeDetector ledgeDetector;

    private float detectionRadius = 5f;

    private bool wanderLeft = false;

    private void Start()
    {
        wanderLeft = Random.value > 0.5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectsWithTag("Player").FirstOrDefault();
            return;
        }

        var diff = Player.transform.position - this.transform.position;
        if (diff.magnitude > detectionRadius)
        {
            Wander();
        }
        else
        {
            FollowPlayer(diff);
        }
       
    }

    private void Wander()
    {
        horizontalInput = 1;
        if (wanderLeft)
        {
            horizontalInput = -1;
        }

        if (ledgeDetector.EdgeRight)
        {
            wanderLeft = true;
        }

        if (ledgeDetector.EdgeLeft)
        {
            wanderLeft = false;
        }
        
        horizontalInput = Mathf.Clamp(
            horizontalInput,
            ledgeDetector.EdgeLeft ? 0 : -1, 
            ledgeDetector.EdgeRight ? 0 : 1);
    }

    private void FollowPlayer(Vector3 diffVector)
    {
        float directionX = diffVector.x;
        
        horizontalInput = 0;
        
        if (directionX > 0)
        {
            //Go right
            horizontalInput = 1;

        }
        else if(directionX < 0)
        {
            //Go left
            horizontalInput = -1;
        }

        horizontalInput = Mathf.Clamp(
            horizontalInput,
            ledgeDetector.EdgeLeft ? 0 : -1, 
            ledgeDetector.EdgeRight ? 0 : 1);
    }
}
