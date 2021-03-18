using System;
using UnityEngine;
using NaughtyAttributes;

[Serializable]
public class SimpleObjectForThrowing
{
	public int SpawnPoint;

	[Range(0, 1)]
	public float PositionOfThrowing = 0.5f;
	public float TimeBeforeThrowing;
	public float ForceOfThrowing;
}
