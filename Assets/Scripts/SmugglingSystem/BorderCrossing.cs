using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCrossing : Waypoint
{
	public float checkInTime;
	[Range(0f, 1f)] public float baseFailPercentage;
	public Type type;

	public enum Type {
		Regular,
		Forest,
		Highway,
		Airport,
	}
}
