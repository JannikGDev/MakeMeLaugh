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

    public SimpleAudioEvent m_shotSFX;

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

        var mousePos = Input.mousePosition;
        var mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        var diffVector =  mouseWorldPos - this.gameObject.transform.position;
        var diffVector2 = new Vector2(diffVector.x, diffVector.y);
        var targetAngle = Vector2.SignedAngle(diffVector2,Vector2.right);
        
        var rotationAngleDegrees = -targetAngle + Random.value * m_spread;

        rotationAngleDegrees -= m_spread / 2f;

        // Create a quaternion that represents the rotation
        Quaternion rotationQuaternion = Quaternion.Euler(0, 0, rotationAngleDegrees);

        // Rotate the original vector using the quaternion
        Vector3 rotatedVector = rotationQuaternion * Vector3.right;
        var parentAngle = Vector2.SignedAngle(transform.parent.TransformVector(Vector3.right), Vector3.right);
        var angle = rotationQuaternion.eulerAngles.z - parentAngle;
        this.transform.rotation = Quaternion.Euler(0,0,angle);

        GameObject newProjectile = Instantiate(m_projectilePrefab, m_shotPos.position, Quaternion.identity);
        var aProjectile = newProjectile.GetComponent<AProjectile>();

        aProjectile.Init(rotatedVector * m_shotForce);

        var look = transform.TransformVector(transform.right);

        GameObject fireVFX = Instantiate(m_fireVFX, m_shotPos.position, Quaternion.LookRotation(look));

        AudioManager.instance.PlayInWorld(transform.position, m_shotSFX);
    }
}