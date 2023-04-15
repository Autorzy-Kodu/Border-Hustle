using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Smuggler
{
	public string fullName;
	public float hirePrice;
	[Range (0f, 1f)] public float tiredness;
	public Dictionary<BorderCrossing.Type, float> experience = new ();
	public List<Trait> traits = new ();
	public Sprite portrait;
}
