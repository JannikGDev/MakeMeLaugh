using System.Collections;
using System.Collections.Generic;
using PlayerControls.Scripts;
using UnityEngine;

public class Movement_Jump : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private GameObject groundChecker;

    [SerializeField] private IInput input;
    
    public float jumpSensitivity = 1f;
    private bool _isGrounded = false;
    
    

    // Update is called once per frame
    void Update()
    {
        if (input.jumpInput && checkIsGrounded())
        {
            _rb.AddForce(Vector2.up * jumpSensitivity);
        }
    }

    private bool checkIsGrounded()
    {
        return groundChecker.GetComponent<Movement_Grounded>().isGrounded;
    }
}
