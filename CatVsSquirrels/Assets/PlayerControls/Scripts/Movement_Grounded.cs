using System;
using UnityEngine;

public class Movement_Grounded : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] private int groundLayer;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == groundLayer)
        {
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.layer == groundLayer)
        {
            isGrounded = false;
        }
    }
}
