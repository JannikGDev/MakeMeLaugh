using UnityEngine;

public class Movement_Horizontal : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _rb;
    public bool moveright = true;

    public float movementSensibility = 1f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput < 0)
        {
            moveright = false;
        }
        else
        {
            moveright = true;
        }
        _rb.AddForce(transform.right * horizontalInput * movementSensibility);

        if (horizontalInput == 0)
        {
            _rb.velocity = new Vector2(0, 0);
        }

        if (_rb.velocity.x > 5)
        {
            Debug.Log("Velocity over 5");
        }
    }
}
