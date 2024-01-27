using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private HeartSprites [] hearts; 

    // Start is called before the first frame update
    void Start()
    {
        hearts = GetComponentsInChildren<HeartSprites>();

        healthComponent.onDoDamage += OnTakeDamage;
    }

    void OnDestroy()
    {
        healthComponent.onDoDamage -= OnTakeDamage;
    }

    // Update is called once per frame
    void OnTakeDamage(int newLife)
    {
        //TODO: show/hide hearts
    }
}
