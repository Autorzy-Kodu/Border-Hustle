using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smuggler
{
	public float hirePrice;
	public string fullName;
	[Range (0f, 1f)] public float tiredness;
	public Dictionary<BorderCrossing.Type, float> experience = new ();
	public List<Trait> traits;
	public Sprite portrait;
}
