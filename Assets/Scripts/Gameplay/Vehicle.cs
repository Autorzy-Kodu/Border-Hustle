using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

[Serializable]
public class Vehicle
{
	public string vehicleName;
	public float price;
	private float durability;
	private float transportTime;

	public void GenerateRandom()
	{
		vehicleName = vehicleNames[Random.Range(0, vehicleNames.Count)];
		price = Random.Range(100f, 34000f);
		durability = Random.Range(0.2f, 1f);
		transportTime = Random.Range(360, 3600);
	}
	
	// TODO tylko do testów
	private List<string> vehicleNames = new List<string>() { "Maluch", "Furgonetka", "Rower", "Prywatny odrzutowiec" };
}
