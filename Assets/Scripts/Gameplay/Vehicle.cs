using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Vehicle
{
	public string vehicleName;
	public float price;
	public float exploatationCost;
	public float durability;
	public float speed;
	[Range(0f, 1f)] public float susMeter;
	public VehicleType type;
	public Sprite thumbnail;
	public GameObject prefab;
	public float unloadTime;
	public int capacity; // FIXME nie działa

	public static Vehicle GenerateRandom()
	{
		Vehicle vehicle = new Vehicle();
		Vehicle vehicleData = GameData.Instance.vehiclesData.vehicles[Random.Range(0, GameData.Instance.vehiclesData.vehicles.Count)];
		// niezmienne
		vehicle.vehicleName = vehicleData.vehicleName;
		vehicle.thumbnail = vehicleData.thumbnail;
		vehicle.prefab = vehicleData.prefab;
		vehicle.unloadTime = vehicleData.unloadTime;
		vehicle.type = vehicleData.type;
		vehicle.capacity = vehicleData.capacity;
		// losowe wariacje
		vehicle.durability = Random.Range(0.25f, 1f);
		float speedVariation = Random.Range(-0.5f, 0.5f);
		vehicle.speed = vehicleData.speed + speedVariation;
		
		vehicle.price = vehicle.price * (1 - (vehicle.durability - 1) * (vehicle.durability - 1)) + speedVariation * 100f;
		return vehicle;
	}
}