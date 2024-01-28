using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    public float pushForce = 50;

    private Rigidbody2D[] bodies;
    // Start is called before the first frame update
    void Start()
    {
        bodies = GetComponentsInChildren<Rigidbody2D>();

        foreach (var body in bodies)
        {
            var force = body.transform.position - transform.position;
            force.Normalize();
            force *= pushForce;
            body.AddForceAtPosition(force, transform.position);
        }
    }
}
