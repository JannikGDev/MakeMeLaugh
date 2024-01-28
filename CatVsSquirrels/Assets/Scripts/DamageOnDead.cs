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
        DamageInRadius(layerMask, transform.position, radius, damage);
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    public static void DamageInRadius(LayerMask layerMask, Vector3 position, float radius, int damage)
    {
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = layerMask;

        List<RaycastHit2D> hits = new List<RaycastHit2D>(20);
        Physics2D.CircleCast(position, radius, Vector3.forward, filter, hits, 0);

        foreach (var raycastHit2D in hits)
        {
            var healthComponent = raycastHit2D.collider.GetComponent<HealthComponent>();

            if (healthComponent == null) continue;

            healthComponent.TakeDamage(damage);
        }
    }
}