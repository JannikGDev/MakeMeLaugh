using System;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    [SerializeField] private int increaseHealth;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("Collision");
        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Add Health: " + increaseHealth);
            int actualHealth = col.GetComponent<HealthComponent>().health;
            if (actualHealth < col.GetComponent<HealthComponent>().healthLimit)
            {
                HeartManager.Instance.OnAddHealth(increaseHealth);
                col.GetComponent<HealthComponent>().health += increaseHealth;
                Destroy(this.gameObject);
            }

        }
    }
}
