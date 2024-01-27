using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class DestroyOnDead : MonoBehaviour
{
    HealthComponent healthComponent;

    public SimpleAudioEvent dieSFX;
    // Start is called before the first frame update
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();

        healthComponent.onDead += OnDie;
    }

    void OnDie()
    {
        AudioManager.instance.PlayInWorld(transform.position, dieSFX);
        
        Destroy(gameObject);
    }
}
