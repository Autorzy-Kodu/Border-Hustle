using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvailableVehicle : MonoBehaviour
{
	[SerializeField] private Vehicle vehicle;
	[SerializeField] private Image vehicleImage; 
	[SerializeField] private TextMeshProUGUI vehicleNameText;
	[SerializeField] private TextMeshProUGUI priceText;
	[SerializeField] private TextMeshProUGUI durabilityText;
	[SerializeField] private TextMeshProUGUI transportTimeText;

	private void Awake()
	{
		vehicle = new Vehicle();
		vehicle.GenerateRandom();
		vehicleNameText.text = vehicle.vehicleName;
		vehicleImage.sprite = vehicle.thumbnail;
		priceText.text = $"{vehicle.price:0.00}zł";
	}
	
	public void Buy()
	{
		GameManager.Instance.BuyVehicle(vehicle);
		Destroy(gameObject);
	}
}