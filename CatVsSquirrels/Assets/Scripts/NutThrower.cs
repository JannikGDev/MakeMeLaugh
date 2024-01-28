using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NutThrower : MonoBehaviour
{
    [SerializeField] private GameObject nutProjectile;

    [SerializeField] private float ThrowStrength = 30;

    [SerializeField] private SimpleAudioEvent attackSFX;
    
    public void ThrowNut(Vector3 direction)
    {
        GameObject nut = GameObject.Instantiate(nutProjectile);
        nut.transform.position = this.transform.position;
        var body =  nut.GetComponent<Rigidbody2D>();
        var targetVelocity = (Vector2)direction.normalized * ThrowStrength;
        var angle = Random.value * 40 - 20;
        
        if (targetVelocity.x > 0)
        {
            body.velocity = RotateBy(targetVelocity, 30+angle);
        }
        else
        {
            body.velocity = RotateBy(targetVelocity, -30+angle);
        }

        AudioManager.instance.PlayInWorld(transform.position, attackSFX);
    }

    private Vector2 RotateBy(Vector2 input, float angleDegrees)
    {
        var angleRadians = Mathf.PI * angleDegrees / 180;
        var normalized = input.normalized;
        var x = normalized.x*Mathf.Cos(angleRadians) - normalized.y*Mathf.Sin(angleRadians);
        var y = normalized.x*Mathf.Sin(angleRadians) + normalized.y*Mathf.Cos(angleRadians);

        return new Vector2(x, y) * input.magnitude;
    }
}
