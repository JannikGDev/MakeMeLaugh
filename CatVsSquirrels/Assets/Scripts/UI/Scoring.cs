using TMPro;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public static Scoring Instance;
    public int score;
    [SerializeField] private TMP_Text scoreText;

    public void Start()
    {
        Instance = this;
        score = 0;
        UpdateScore(0);
    }
    public void UpdateScore(int i)
    {
        score = score + i;
        scoreText.text = "Score: " + score;
    }

}
