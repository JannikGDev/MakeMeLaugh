using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(HealthComponent))]
public class DamageOnDead : MonoBehaviour
{
    public int damage = 5;
    public float radius = 3;
    HealthComponent healthComponent;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();

        healthComponent.onDead += OnDie;
    }

    void OnDie()
    {
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = layerMask;

        List<RaycastHit2D> hits = new List<RaycastHit2D>(20);
        Physics2D.CircleCast(transform.position, radius, transform.forward, filter, hits, 0);

        foreach (var raycastHit2D in hits)
        {
            var healthComponent = raycastHit2D.collider.GetComponent<HealthComponent>();

            if(healthComponent == null) continue;

            healthComponent.TakeDamage(damage);
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}