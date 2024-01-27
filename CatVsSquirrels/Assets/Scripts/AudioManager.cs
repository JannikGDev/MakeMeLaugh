using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject audioSourcePrefab;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void PlayInWorld(Vector3 position, SimpleAudioEvent simpleAudioEvent)
    {
        var newSource = Instantiate(audioSourcePrefab, position, Quaternion.identity);

        simpleAudioEvent.Play(newSource.GetComponent<AudioSource>());
    }
}
