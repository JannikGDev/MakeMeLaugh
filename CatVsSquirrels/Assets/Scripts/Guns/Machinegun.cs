using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machinegun : MonoBehaviour
{
    public float m_spread = 10;
    public float m_shotForce = 20;
    public float m_shotDelay = 0.2f;

    private float m_lastShotTime = 0;

    public Transform m_shotPos;

    public GameObject m_projectilePrefab;

    public GameObject m_fireVFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }

    private void UpdateInput()
    {
        if (Input.GetMouseButton(0))
        {
            if(m_lastShotTime + m_shotDelay > Time.time) return;

            m_lastShotTime = Time.time;
            ShotProjectile();
        }
    }

    private void ShotProjectile()
    {
        // The angle in degrees by which you want to rotate the vector
        //float rotationAngleDegrees = 45.0f;

        var rotationAngleDegrees = Random.value * m_spread;

        rotationAngleDegrees -= m_spread / 2f;

        // Convert the rotation angle from degrees to radians
        float rotationAngleRadians = rotationAngleDegrees * Mathf.Deg2Rad;

        // Create a quaternion that represents the rotation
        Quaternion rotationQuaternion = Quaternion.Euler(0, 0, rotationAngleDegrees);

        // Rotate the original vector using the quaternion
        Vector3 rotatedVector = rotationQuaternion * transform.parent.TransformVector(Vector3.right);

        GameObject newProjectile = Instantiate(m_projectilePrefab, m_shotPos.position, Quaternion.identity);
        var aProjectile = newProjectile.GetComponent<AProjectile>();

        aProjectile.Init(rotatedVector * m_shotForce);

        transform.right = rotatedVector;

        GameObject fireVFX = Instantiate(m_fireVFX, m_shotPos.position, Quaternion.LookRotation(transform.right));
    }
}