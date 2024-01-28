using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(HealthComponent))]
public class TakeFallDamage : MonoBehaviour
{
    //public int damage = 5;
    public float forceThreshold = 8;
    public float damageMul = 1;
    public float doDamageForceThreshold = 10;

    public LayerMask layerMask;

    private HealthComponent healthComponent;
    private Rigidbody2D rigidbody2D;

    void OnEnable()
    {
        healthComponent = GetComponent<HealthComponent>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        var force = rigidbody2D.velocity.magnitude;//collision.relativeVelocity.magnitude;
        int damage = (int)(force / 3f * damageMul);

        if(force < forceThreshold) return;

        Debug.Log("damage: " + damage);

        if(damage < 0) return;

        //if (collision.collider.gameObject.layer == layerMask.value)
        //{
            healthComponent.TakeDamage(damage);
        //}

        if (force > doDamageForceThreshold)
        {
            var otherHealthComponent = collision.collider.GetComponent<HealthComponent>();
            if (otherHealthComponent)
            {
                otherHealthComponent.TakeDamage(damage);
            }
        }
    }
}
