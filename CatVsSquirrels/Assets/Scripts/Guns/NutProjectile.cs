using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AProjectile))]
public class NutProjectile : MonoBehaviour
{
    private AProjectile aProjectile;

    private bool animStarted = false;
    public Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {
        aProjectile = GetComponent<AProjectile>();
    }

    // Update is called once per frame
    void Update()
    {
        if(animStarted) return;

        if (aProjectile.lifeTime < 2)
        {
            animStarted = true;
            m_Animator.SetTrigger("blink");
        }
    }
}
