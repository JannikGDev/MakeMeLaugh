using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Movement_Grounded : MonoBehaviour
{
    public bool isGrounded;
    private Collider2D collider;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        collider = this.GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (collider == null)
            return;
        
        //Check if ground layers are touching
        isGrounded =  collider.IsTouchingLayers(layerMask);
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (collider == null)
            return;
        
        //Check if ground layers are touching
        isGrounded =  collider.IsTouchingLayers(layerMask);
    }
}
