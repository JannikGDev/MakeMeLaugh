using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;

public class Movement_Grounded : MonoBehaviour
{
    public bool isGrounded;
    [SerializeField] private float rayLength = 1.0f;
    [SerializeField] private LayerMask groundMask;

    void FixedUpdate()
    {
        isGrounded = false;
        if (Physics2D.Raycast(transform.position, Vector3.down, rayLength, groundMask))
        {
            isGrounded = true;
        }
    }
}
