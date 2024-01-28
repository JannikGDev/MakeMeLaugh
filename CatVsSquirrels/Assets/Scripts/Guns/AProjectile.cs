using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AProjectile : MonoBehaviour
{
    public float lifeTime = 5;
    private float m_maxLie = 1;
    public int damage = 2;

    public GameObject m_vfxPrefab;
    public GameObject m_onDestroyVFXPrefab;

    private Rigidbody2D m_body;

    private bool collided = false;
    public bool destroyOnHit = false;

    private bool m_needDestroy = false;

    public delegate void OnDestroy();
    public event OnDestroy onDestroy;


    void OnEnable()
    {
        m_maxLie = lifeTime;
        m_body = GetComponent<Rigidbody2D>();
    }

    public void Init(Vector3 force)
    {
        m_body.AddForce(force);
    }

    void Update()
    {
        lifeTime -= Time.deltaTime;

        if (lifeTime < 0)
        {
            m_needDestroy = true;
        }

        if (m_needDestroy)
        {
            if(m_onDestroyVFXPrefab) Instantiate(m_onDestroyVFXPrefab, transform.position, Quaternion.identity);

            onDestroy?.Invoke();
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collided) return;

        if (collision.contactCount > 0)
        {
            var contact = collision.contacts[0];

            if (m_vfxPrefab)
            {
                var contactVFX = Instantiate(m_vfxPrefab, transform.position, Quaternion.LookRotation(contact.normal));
            }

            var healthComponent = collision.collider.GetComponent<HealthComponent>();

            if (healthComponent)
            {
                healthComponent.TakeDamage(damage);

                destroyOnHit = true;
            }
        }

        if (destroyOnHit)
        {
            collided = true;
            m_needDestroy = true;
        }
    }
}
