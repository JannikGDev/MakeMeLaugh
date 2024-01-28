using UnityEngine;

public class AddHealth : MonoBehaviour
{
    [SerializeField] private int increaseHealth;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.GetComponent<HealthComponent>().health =+ increaseHealth;
            Destroy(this.gameObject);
        }
    }
}
