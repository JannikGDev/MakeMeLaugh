using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using Object = UnityEngine.Object;


public class AudioManager : MonoBehaviour
{
    public GameObject audioSourcePrefab;
    private StudioEventEmitter EventEmitter;

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

        EventEmitter = this.GetComponent<StudioEventEmitter>();
    }

    public void EnterScene()
    {
        EventEmitter.SetParameter("EnterGame",1);
        EventEmitter.SetParameter("Health",7);
    }

    public void PlayInWorld(Vector3 position, SimpleAudioEvent simpleAudioEvent)
    {
        var newSource = Instantiate(audioSourcePrefab, position, Quaternion.identity);

        simpleAudioEvent.Play(newSource.GetComponent<AudioSource>());
    }
}
