using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int health = 14;
    public int healthLimit = 13;

    public delegate void OnDoDamage(int newHealth);
    public event OnDoDamage onDoDamage;

    public delegate void OnDead();
    public event OnDead onDead;

    public GameObject m_damageStatPrefab;

    public void TakeDamage(int damage)
    {
        if(health == 0) return;

        health -= damage;

        if(health < 0) health = 0;

        if (m_damageStatPrefab)
        {
            var damageStat = Instantiate(m_damageStatPrefab, transform.position + Vector3.up * 1.5f, Quaternion.identity);
            damageStat.GetComponent<DamageStat>().Init(damage);
        }

        if (health == 0) onDead?.Invoke();

        onDoDamage?.Invoke(health);
    }
}