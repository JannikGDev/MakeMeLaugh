using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayerControls.Scripts;


public class Pause : MonoBehaviour
{
    [SerializeField] private IInput input;
    public bool gameIsPaused = false;
    private void Update()
    {
        bool pauseButton = input.pauseInput;
        if (pauseButton && !gameIsPaused)
        {
            Time.timeScale = 0.0f;
            gameIsPaused = true;
            Debug.Log(gameIsPaused);
        }
        else if (pauseButton && gameIsPaused)
        {
            Time.timeScale = 1.0f;
            gameIsPaused = false;
        }


    }
}
