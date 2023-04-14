using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractsManager : MonoBehaviour
{
	[SerializeField] private GameObject newContractPrefab;
	[SerializeField] private int availableContracts = 3;

	private void Awake()
	{
		GenerateContracts();
	}

	public void GenerateContracts()
	{
		while (transform.childCount < availableContracts)
		{
			// TODO wygeneruj losowy kontrakt
			Instantiate(newContractPrefab, transform.position, Quaternion.identity, transform);
		}
	}
}
