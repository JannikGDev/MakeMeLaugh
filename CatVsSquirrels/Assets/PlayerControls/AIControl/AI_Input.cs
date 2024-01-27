using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using PlayerControls.Scripts;
using UnityEngine;

public class AI_Input : IInput
{
    private GameObject Player;
    [SerializeField] private LedgeDetector ledgeDetector;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player == null)
        {
            Player = GameObject.FindGameObjectsWithTag("Player").FirstOrDefault();
            return;
        }

        float direction = Player.transform.position.x - this.transform.position.x;

        horizontalInput = 0;
        
        if (ledgeDetector.EdgeRight)
        {
            horizontalInput += -1;
        }
        
        if (ledgeDetector.EdgeLeft)
        {
            horizontalInput += 1;
        }
        
        if (direction > 0)
        {
            //Go right
            horizontalInput = 1;

        }
        else if(direction < 0)
        {
            //Go left
            horizontalInput = -1;
        }

        horizontalInput = Mathf.Clamp(horizontalInput,-1, 1);
    }
    
    
}
