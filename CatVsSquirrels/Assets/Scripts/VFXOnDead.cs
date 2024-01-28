using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class VFXOnDead : MonoBehaviour
{
    HealthComponent healthComponent;

    public GameObject m_VFXPrefab;

    public SimpleAudioEvent m_SFX;
    // Start is called before the first frame update
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();

        healthComponent.onDead += OnDie;
    }

    void OnDie()
    {
        AudioManager.instance.PlayInWorld(transform.position, m_SFX);

        Instantiate(m_VFXPrefab, transform.position, Quaternion.identity);
    }
}