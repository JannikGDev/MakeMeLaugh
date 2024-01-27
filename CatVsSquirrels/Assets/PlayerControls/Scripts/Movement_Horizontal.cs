using PlayerControls.Scripts;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class Movement_Horizontal : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb;
    [SerializeReference] private IInput input;
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
        _rb.AddForce(transform.right * (horizontalInput * movementSensibility));

        if (horizontalInput == 0)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }

        if (_rb.velocity.x > velocityLimit)
        {
            _rb.velocity = new Vector2(velocityLimit, _rb.velocity.y);
            Debug.Log("Velocity over 5");
        }
    }
}
