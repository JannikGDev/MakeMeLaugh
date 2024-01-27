using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int health = 14;

    public delegate void OnDoDamage(int newHealth);
    public event OnDoDamage onDoDamage;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if(health < 0) health = 0;

        onDoDamage?.Invoke(health);
    }
}