using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Jump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject groundChecker;
    public float jumpSensitivity = 1f;
    private bool _isGrounded = false;
    
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Vertical") && checkIsGrounded())
        {
            float verticalInput = Input.GetAxis("Vertical");
            _rb.AddForce(Vector2.up * jumpSensitivity);
        }
    }

    private bool checkIsGrounded()
    {
        return groundChecker.GetComponent<Movement_Grounded>().isGrounded;
    }
}
