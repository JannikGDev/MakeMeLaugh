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
            Debug.Log(moveright);
        }
        else
        {
            moveright = true;
            Debug.Log(moveright);
        }
        _rb.AddForce(transform.right * horizontalInput * movementSensibility);
    }
}
