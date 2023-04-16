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
		FailSafe();
		GenerateVehicles();
	}

	private void Start()
	{
		StartCoroutine(EAddNewVehicles());
	}

	public void FailSafe()
	{
		GameObject firstCarGO = Instantiate(newVehiclePrefab, transform.position, Quaternion.identity, transform);
		AvailableVehicle availableVehicle = firstCarGO.GetComponent<AvailableVehicle>();
		Vehicle firstVehicle = GameData.Instance.vehiclesData.vehicles[0];
		availableVehicle.SetVehicle(firstVehicle);
	}

	public void GenerateVehicles()
	{
		while (transform.childCount < availableVehicles)
		{
			Instantiate(newVehiclePrefab, transform.position, Quaternion.identity, transform);
		}
	}

	IEnumerator EAddNewVehicles()
	{
		while (true)
		{
			GenerateVehicles();
			yield return new WaitForSeconds(60f);
		}
	}
}