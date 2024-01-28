using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class DestroyWhenAudioSourceNotPLaying : MonoBehaviour
{
    private AudioSource m_audioSource;

    void OnEnable()
    {
        m_audioSource = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if(!m_audioSource.isPlaying) Destroy(gameObject);
    }
}
