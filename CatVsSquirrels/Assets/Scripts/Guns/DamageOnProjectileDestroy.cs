using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AProjectile))]
public class DamageOnProjectileDestroy : MonoBehaviour
{
    public LayerMask layerMask;
    public float radius = 2;
    public int damage = 3;

    private AProjectile m_Projectile;
    // Start is called before the first frame update
    void Start()
    {
        m_Projectile = GetComponent<AProjectile>();

        m_Projectile.onDestroy += DoDamage;
    }

    // Update is called once per frame
    void DoDamage()
    {
        DamageOnDead.DamageInRadius(layerMask, transform.position, radius, damage);
    }
}
