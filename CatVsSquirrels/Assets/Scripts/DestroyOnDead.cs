using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class DestroyOnDead : MonoBehaviour
{
    HealthComponent healthComponent;

    public SimpleAudioEvent dieSFX;

    private bool needDestroy = false;

    // Start is called before the first frame update
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();

        healthComponent.onDead += OnDie;
    }

    void Update()
    {
        if(needDestroy) Destroy(gameObject);
    }

    void OnDie()
    {
        if(dieSFX) AudioManager.instance.PlayInWorld(transform.position, dieSFX);

        needDestroy = true;
    }
}
