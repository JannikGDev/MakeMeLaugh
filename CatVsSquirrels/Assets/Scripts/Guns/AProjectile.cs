using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AProjectile : MonoBehaviour
{
    public int damage = 2;

    public GameObject m_vfxPrefab;
    public GameObject m_damageStatPrefab;

    private Rigidbody2D m_body;

    private bool collided = false;
    public bool destroyOnHit = false;

    private bool m_needDestroy = false;


    void OnEnable()
    {
        m_body = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector3 force)
    {
        m_body.AddForce(force);
    }

    void Update()
    {
        if(m_needDestroy) Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collided) return;

        collided = true;

        if (collision.contactCount > 0)
        {
            var contact = collision.contacts[0];
            //contact.normal

            var contactVFX = Instantiate(m_vfxPrefab, transform.position, Quaternion.LookRotation(contact.normal));

            var healthComponent = collision.collider.GetComponent<HealthComponent>();

            if (healthComponent)
            {
                healthComponent.TakeDamage(damage);
            }

            if (m_damageStatPrefab && healthComponent)
            {
                var damageStat = Instantiate(m_damageStatPrefab, collision.collider.transform.position + Vector3.up * 1.5f, Quaternion.identity);
                damageStat.GetComponent<DamageStat>().Init(damage);
            }
        }
        

        if (destroyOnHit) m_needDestroy = true;
    }
}
