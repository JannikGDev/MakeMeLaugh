using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[RequireComponent(typeof(HealthComponent))]
public class Enemy_Score : MonoBehaviour
{
    public int deathScore = 50;
    private HealthComponent _healthComponent;

    // Start is called before the first frame update
    void Start()
    {
        _healthComponent = GetComponent<HealthComponent>();
        _healthComponent.onDead += DeclareScore;
    }

    void DeclareScore()
    {
        // Report the new deathScore to the Scoring manager, which updates the UI
        Scoring.Instance.UpdateScore(deathScore);
    }
}
