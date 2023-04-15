using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "VehiclesData", menuName = "ScriptableObjects/VehiclesData", order = 1)]
public class VehiclesData : ScriptableObject
{
	public List<Vehicle> vehicles;
}