using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;
using System;

[CreateAssetMenu(menuName = "Audio Events/Simple")]
public class SimpleAudioEvent : AudioEvent
{
	public AudioClip[] clips;

	public RangedFloat volume;

	[MinMaxRange(0, 2)]
	public RangedFloat pitch;
	[Space(10)]
	[Range(0, 1)]
	public float minDelay = 0;

	[NonSerialized]
	private float lastTime = 0;

    public float currentClipLength = 0;


    public override void Play(AudioSource source)
	{
		if (clips.Length == 0) return;
		
		if(Application.isPlaying && (minDelay > 0 && (lastTime + minDelay) > Time.realtimeSinceStartup))
        {
			return;
        }

		source.clip = clips[Random.Range(0, clips.Length)];
		source.volume = Random.Range(volume.minValue, volume.maxValue);
		source.pitch = Random.Range(pitch.minValue, pitch.maxValue);
		source.Play();

        currentClipLength = source.clip.length;

        lastTime = Time.realtimeSinceStartup;
	}
}