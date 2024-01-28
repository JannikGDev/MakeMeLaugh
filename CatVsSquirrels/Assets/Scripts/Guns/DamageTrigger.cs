using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrigger : MonoBehaviour
{
    [SerializeField] private string playerTag; 
    private HealthComponent healthComponent;
    public bool destroyOnPlayerHit = true;
    
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag(playerTag))
        {
            
            // Get healthComponent from collision
            healthComponent = col.collider.GetComponent<HealthComponent>();
            SubstractLife(1);
            
            // Destroys nuts, when hit player and turned on
            if (destroyOnPlayerHit)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void SubstractLife(int damage)
    {
        healthComponent.TakeDamage(damage);
        Debug.Log("Life: " + healthComponent.GetComponent<HealthComponent>().health);
    }
}
