using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetector : MonoBehaviour
{
    [SerializeField] private float horizontalDistance = 1f;
    [SerializeField] private float downwardDistance = 3f;

    public bool EdgeRight = false;
    public bool EdgeLeft = false;
    
    // Update is called once per frame
    void FixedUpdate()
    {
        var position = this.transform.position;
        var rightStart = position + Vector3.right * horizontalDistance;
        var leftStart = position + Vector3.left * horizontalDistance;

        var hitRight = Physics2D.Raycast(rightStart, Vector3.down, downwardDistance);
        var hitLeft = Physics2D.Raycast(leftStart, Vector3.down, downwardDistance);

        EdgeRight = hitRight.collider == null;
        EdgeLeft = hitLeft.collider == null;
    }

    private void OnDrawGizmosSelected()
    {
        var position = this.transform.position;
        var rightStart = position + Vector3.right * horizontalDistance;
        var rightEnd = rightStart + downwardDistance * Vector3.down;
        
        var leftStart = position + Vector3.left * horizontalDistance;
        var leftEnd = leftStart + downwardDistance * Vector3.down;
        
        Gizmos.DrawLine(rightStart, rightEnd);
        Gizmos.DrawLine(leftStart, leftEnd);
    }
}
