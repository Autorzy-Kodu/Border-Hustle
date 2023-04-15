using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TruckColorize : MonoBehaviour
{
	[SerializeField] private Renderer r;
	
	private void Awake()
	{
		r.materials[0].color = Random.ColorHSV();
		r.materials[1].color = Random.ColorHSV();
	}
}
