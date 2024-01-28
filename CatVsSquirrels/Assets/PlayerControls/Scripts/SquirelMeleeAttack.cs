using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirelMeleeAttack : MonoBehaviour
{
    public SimpleAudioEvent m_biteSFX;
    public Animator m_animator;
    public float m_attackDelay = 2.0f;
    public float m_attackRadius = 1;

    public float m_lastAttackTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_lastAttackTime = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        if(m_lastAttackTime + m_attackDelay > Time.time) return;

        if(!IsPlayerInRadius()) return;

        m_lastAttackTime = Time.time;

        AudioManager.instance.PlayInWorld(transform.position, m_biteSFX);
        m_animator.SetTrigger("melee_attack");

        Player.instance.GetComponent<HealthComponent>().TakeDamage(1);
    }

    public bool IsPlayerInRadius()
    {
        if (Vector3.Distance(Player.instance.transform.position, transform.position) < m_attackRadius)
        {
            return true;
        }

        return false;
    }
}
