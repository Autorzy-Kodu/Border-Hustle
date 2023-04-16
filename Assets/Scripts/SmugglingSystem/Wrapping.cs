using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Wrapping
{
	public string wrappingName;
	public float susMeter;
	public float price;
	[Range(0f, 3f)] public float productsPriceMultiplier;
}
