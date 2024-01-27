using System;

[Serializable]
public struct RangedFloat
{
	public float minValue;
	public float maxValue;

	public float random => UnityEngine.Random.Range(minValue, maxValue);
}