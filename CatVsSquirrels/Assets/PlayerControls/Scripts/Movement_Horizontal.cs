using PlayerControls.Scripts;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Movement_Horizontal : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb;
    [SerializeReference] private IInput input;
    [SerializeField] private Movement_Grounded groundChecker;
    
    public bool moveright = true;
    public float velocityLimit = 10.0f;

    public float movementSensibility = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = input.horizontalInput;
        if (horizontalInput < 0)
        {
            moveright = false;
        }
        else
        {
            moveright = true;
        }

        _rb.gameObject.transform.localScale = moveright ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);
        
        _rb.AddForce(transform.right * (horizontalInput * movementSensibility));

        if (Mathf.Abs(horizontalInput) < 0.1f && groundChecker.isGrounded)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }

        if (Mathf.Abs(_rb.velocity.x) > velocityLimit)
        {
            var limitedVelocity = Mathf.Clamp(_rb.velocity.x, -velocityLimit, velocityLimit);
            _rb.velocity = new Vector2(limitedVelocity, _rb.velocity.y);
        }
    }
}
