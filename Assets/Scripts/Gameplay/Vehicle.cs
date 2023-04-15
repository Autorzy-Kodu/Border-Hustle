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
	public VehicleType type;
	public Sprite thumbnail;
	public GameObject prefab;
	public float unloadTime;
	public int capacity;
	public Dictionary<string, int> load = new ();

	public void GenerateRandom()
	{
		Debug.Log(GameData.Instance.vehiclesData.vehicles.Count);
		Vehicle vehicle = GameData.Instance.vehiclesData.vehicles[Random.Range(0, GameData.Instance.vehiclesData.vehicles.Count)];
		vehicleName = vehicle.vehicleName;
		thumbnail = vehicle.thumbnail;
		price = vehicle.price;
		durability = vehicle.durability;
		speed = vehicle.speed;
		unloadTime = vehicle.unloadTime;
		prefab = vehicle.prefab;
	}
}