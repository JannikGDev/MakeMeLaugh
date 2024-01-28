using System;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    [SerializeField] private int increaseHealth;
    public SimpleAudioEvent sfx;

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("Collision");
        if (col.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Add Health: " + increaseHealth);
            int actualHealth = col.GetComponent<HealthComponent>().health;
            if (actualHealth < col.GetComponent<HealthComponent>().healthLimit)
            {
                if(sfx) AudioManager.instance.PlayInWorld(transform.position, sfx);

                HeartManager.Instance.OnAddHealth(increaseHealth);
                col.GetComponent<HealthComponent>().health += increaseHealth;
                Destroy(this.gameObject);
            }

        }
    }
}
