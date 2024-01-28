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
            return;
        }
        else
        {
            instance = this;
            Object.DontDestroyOnLoad(this);
        }
        
        EventEmitter = this.GetComponent<StudioEventEmitter>();
        EventEmitter.Play();
    }

    public void EnterScene()
    {
        EventEmitter.SetParameter("EnterGame",1);
        EventEmitter.SetParameter("Health",7);
    }

    public void SetHealth(int value)
    {
        EventEmitter.SetParameter("Health",value/2);
    }
    
    public void SetIntensity(float value)
    {
        if (value < 0.25f)
        {
            EventEmitter.SetParameter("Intensity",0);
        }
        else if (value < 0.5f)
        {
            EventEmitter.SetParameter("Intensity",1);
        }
        else if (value < 0.75f)
        {
            EventEmitter.SetParameter("Intensity",2);
        }
        else
        {
            EventEmitter.SetParameter("Intensity",3);
        }
    }

    public void PlayInWorld(Vector3 position, SimpleAudioEvent simpleAudioEvent)
    {
        var newSource = Instantiate(audioSourcePrefab, position, Quaternion.identity);

        simpleAudioEvent.Play(newSource.GetComponent<AudioSource>());
    }
}
