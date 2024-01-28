using PlayerControls.Scripts;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Movement_Horizontal : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb;
    [SerializeReference] private IInput input;
    [SerializeField] private Movement_Grounded groundChecker;
    [SerializeField] private SpriteRenderer sprite;
    
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
        else if (horizontalInput > 0)
        {
            moveright = true;
        }

        var scale = transform.localScale.y;
        sprite.transform.localScale = moveright ? new Vector3(scale, scale, scale) : new Vector3(-scale, scale, scale);
        
        _rb.AddForce(transform.right * (horizontalInput * movementSensibility));

        if (Mathf.Abs(horizontalInput) < 0.05f && groundChecker.isGrounded)
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
