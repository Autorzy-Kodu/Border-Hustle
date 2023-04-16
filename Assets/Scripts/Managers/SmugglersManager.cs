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

	private void Start()
	{
		StartCoroutine(EAddNewSmugglers());
	}

	public void GenerateSmugglers()
	{
		while (transform.childCount < availableSmugglers)
		{
			Instantiate(newSmugglerPrefab, transform.position, Quaternion.identity, transform);
		}
	}
	
	IEnumerator EAddNewSmugglers()
	{
		while (true)
		{
			GenerateSmugglers();
			yield return new WaitForSeconds(UnityEngine.Random.Range(45f, 60f));
		}
	}
}
