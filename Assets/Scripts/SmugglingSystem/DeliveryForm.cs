using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryForm : Window
{
	[SerializeField] private TMP_Dropdown contractDropdown;
	[SerializeField] private TMP_Dropdown smugglersDropdown;
	[SerializeField] private TMP_Dropdown roadDropdown;
	[SerializeField] private TMP_Dropdown wrappingDropdown;
	[SerializeField] private TMP_Dropdown vehicleDropdown;
	[SerializeField] private TextMeshProUGUI deliveryCostsText;
	[SerializeField] private TextMeshProUGUI estimatedEarningsText;

	private void Start()
	{
		roadDropdown.ClearOptions();
		List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
		foreach (Road road in Map.Instance.roads)
		{
			TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData
			{
				text = road.roadName,
				image = road.sprite
			};
			options.Add(optionData);
		}
		roadDropdown.AddOptions(options);
	}

	public void SetContract(TMP_Dropdown change)
	{
		Debug.Log($"{change.value} chosen");
		
		CalculateEarnings();
	}
	
	public void SetSmuggler(TMP_Dropdown change)
	{
		Debug.Log($"{change.value} chosen");
		
		CalculateEarnings();
	}
	
	public void SetRoad(TMP_Dropdown change)
	{
		Debug.Log($"{change.value} chosen");
		
		CalculateEarnings();
	}
	
	public void SetWrapping(TMP_Dropdown change)
	{
		Debug.Log($"{change.value} chosen");
		
		CalculateEarnings();
	}
	
	public void SetVehicle(TMP_Dropdown change)
	{
		Debug.Log($"{change.value} chosen");
		
		CalculateEarnings();
	}

	void CalculateEarnings()
	{

	}

	public void Send()
	{
		IllegalTransport illegalTransport = new IllegalTransport();
		
		// TODO skompletuj transport
		
		Map.Instance.roads[roadDropdown.value].SmuggleUsingThisRoad(GameData.Instance.vehiclesData.vehicles[vehicleDropdown.value].prefab, illegalTransport);
	}
}
