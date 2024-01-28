using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public static HeartManager Instance;
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private HeartSprites [] hearts;

    private int lastHealth = 14;

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

    public void OnAddHealth(int i)
    {
        OnTakeDamage(healthComponent.health + i);
    }
    // Update is called once per frame
    public void OnTakeDamage(int newLife)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            var heartValue = Mathf.Clamp(newLife - (i * 2),0,2);
            
            switch (heartValue)
            {
                case 2: 
                    hearts[i].showFullHeart();
                    //Debug.Log("Should show full heart");
                    break;
                case 1: 
                    hearts[i].showHalfHeart();
                    //Debug.Log("Should show half heart");
                    break;
                case 0:
                    hearts[i].showEmptyHeart();
                    //Debug.Log("Should show empty heart");
                    break;
            }
        }
        
        AudioManager.instance.SetHealth(newLife);

        // Game Over
        if (newLife == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
        Time.timeScale = 0;
        Debug.Log("Game over!");
    }
}
