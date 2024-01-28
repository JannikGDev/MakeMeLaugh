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
            col.GetComponent<HealthComponent>().health += increaseHealth;
            HeartManager.Instance.OnAddHealth(increaseHealth);
            Destroy(this.gameObject);
        }
    }
}
