using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleManager : MonoBehaviour
{
	[SerializeField] private GameObject newVehiclePrefab;
	[SerializeField] private int availableVehicles = 3;

	private void Awake()
	{
		GenerateContracts();
	}

	public void GenerateContracts()
	{
		while (transform.childCount < availableVehicles)
		{
			// TODO wygeneruj losowy pojazd
			Instantiate(newVehiclePrefab, transform.position, Quaternion.identity, transform);
		}
	}
}