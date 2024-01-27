using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int health = 14;

    public delegate void OnDoDamage(int newHealth);
    public event OnDoDamage onDoDamage;

    public delegate void OnDead();
    public event OnDead onDead;

    public void TakeDamage(int damage)
    {
        if(health == 0) return;

        health -= damage;

        if(health < 0) health = 0;

        if(health == 0) onDead?.Invoke();

        onDoDamage?.Invoke(health);
    }
}