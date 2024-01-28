using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public static HeartManager Instance;
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private HeartSprites [] hearts;
    [SerializeField] private GameObject restartButton;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        hearts = GetComponentsInChildren<HeartSprites>();
        healthComponent.onDoDamage += OnTakeDamage;
    }

    void OnDestroy()
    {
        // Taking Damage
        healthComponent.onDoDamage -= OnTakeDamage;
    }

    // Update is called once per frame
    void OnTakeDamage(int newLife)
    {
        int index = newLife / 2;
        int heartvalue = newLife % 2;
        
        // Takes the heartvalue, which can be half or full
        switch (heartvalue)
        {
            case 1: 
                hearts[index].showHalfHeart();
                Debug.Log("Should show half heart");
                break;
            case 0:
                hearts[index].showEmptyHeart();
                Debug.Log("Should show empty heart");
                break;
        }
        
        // Game Over
        if (newLife == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        //TODO: Add GameOver Screen
        restartButton.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("Game over!");
    }
}
