using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class AProjectile : MonoBehaviour
{
    public GameObject m_vfxPrefab;

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
        }

        if (destroyOnHit) m_needDestroy = true;
    }
}
