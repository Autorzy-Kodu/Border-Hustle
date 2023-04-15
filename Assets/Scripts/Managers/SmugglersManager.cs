using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmugglersManager : MonoBehaviour
{
	[SerializeField] private GameObject newSmugglerPrefab;
	[SerializeField] private int availableSmugglers = 3;

	private void Awake()
	{
		GenerateSmugglers();
	}

	public void GenerateSmugglers()
	{
		while (transform.childCount < availableSmugglers)
		{
			// TODO wygeneruj losowego przemytnika
			Instantiate(newSmugglerPrefab, transform.position, Quaternion.identity, transform);
		}
	}
}
