using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageStat : MonoBehaviour
{
    public Easings.Functions easing = Easings.Functions.Linear;

    private float m_time = 1;
    public float yOffset = 1;
    private Vector3 A = Vector3.zero;
    private Vector3 B = Vector3.zero;
    public TextMesh m_Text;

    public void Init(float damage)
    {
        m_Text.text = "" + damage;
    }

    // Start is called before the first frame update
    void Start()
    {
        var offset = new Vector3(Random.value - 0.5f, Random.value - 0.5f, 0);
        offset *= 0.5f;
        transform.position += offset;
        A = transform.position;
        B = A + Vector3.up * yOffset;
    }

    // Update is called once per frame
    void Update()
    {
        m_time -= Time.deltaTime;

        var eas = Easings.Interpolate(1 - m_time, easing);
        transform.position = Vector3.Lerp(A, B, eas);

        if (m_time < 0)
        {
            Destroy(gameObject);
        }
    }
}
