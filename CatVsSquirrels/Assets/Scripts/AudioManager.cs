using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;


public class AudioManager : MonoBehaviour
{
    public GameObject audioSourcePrefab;

    public static AudioManager instance;

    private void OnEnable()
    {
        if (AudioManager.instance != null)
        {
            GameObject.Destroy(this);
        }
        else
        {
            instance = this;
            Object.DontDestroyOnLoad(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void PlayInWorld(Vector3 position, SimpleAudioEvent simpleAudioEvent)
    {
        var newSource = Instantiate(audioSourcePrefab, position, Quaternion.identity);

        simpleAudioEvent.Play(newSource.GetComponent<AudioSource>());
    }
}
