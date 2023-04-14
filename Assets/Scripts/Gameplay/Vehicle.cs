using System;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

[Serializable]
public class Vehicle
{
	public string vehicleName;
	public float price;
	public float durability;
	public float speed;

	public void GenerateRandom()
	{
		vehicleName = vehicleNames[Random.Range(0, vehicleNames.Count)];
		price = Random.Range(100f, 34000f);
		durability = Random.Range(0.2f, 1f);
		speed = Random.Range(0.1f, 5f);
	}
	
	// TODO tylko do testów
	private List<string> vehicleNames = new List<string>() { "Maluch", "Furgonetka", "Rower", "Prywatny odrzutowiec" };
}
