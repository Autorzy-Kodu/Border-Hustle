using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableVehicle : MonoBehaviour
{
	private Vehicle vehicle;
	
	// TODO aktywowane przyciskami z zewnątrz
	public void Buy()
	{
		GameManager.Instance.BuyVehicle(vehicle);
		Destroy(gameObject);
	}
}