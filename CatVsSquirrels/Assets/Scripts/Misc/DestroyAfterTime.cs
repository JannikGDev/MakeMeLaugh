using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float m_time = 5;

    // Update is called once per frame
    void Update()
    {
        m_time -= Time.deltaTime;

        if(m_time < 0)
        {
            Destroy(gameObject);
        }
    }
}
