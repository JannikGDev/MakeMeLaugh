using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class InstatiateOnDead : MonoBehaviour
{
    public HealthComponent healthComponent;

    public GameObject m_prefab;

    // Start is called before the first frame update
    void Start()
    {
        healthComponent.onDead += OnDie;
    }
   

    void OnDie()
    {
        Instantiate(m_prefab, transform.position, transform.rotation);
    }
}
