using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody2D))]
public class AlignByVelocity : MonoBehaviour
{
    private Rigidbody2D body;
    
    private void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var velocity = body.velocity;

        var angle = Vector2.SignedAngle(velocity, Vector2.right);

        this.transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
