using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	[SerializeField] private float cash;
	public List<Contract> activeContracts = new();
	public List<Smuggler> hiredSmugglers = new();
	public List<Vehicle> vehicles = new();
	
	public float Cash
	{
		get => cash;
		set {
			cash = value;
			UIManager.Instance.Cash = cash;
		}
	}

	public float GameSpeed {
		set => Time.timeScale = value;
	}

	public int MaxContractsLimit { get; set; }
	public int MaxSmugglersLimit { get; set; }
	public int MaxVehiclesLimit { get; set; }

	protected void Start()
	{
		base.Awake();
		Cash = 100;
		MaxContractsLimit = 3;
		MaxSmugglersLimit = 3;
		MaxVehiclesLimit = 3;
	}

	public void AddContract(Contract contract)
	{
		if (activeContracts.Count >= MaxContractsLimit)
		{
			Debug.LogWarning("Max contracts limit reached!");
			return;
		}
		
		activeContracts.Add(contract);
		UIManager.Instance.AddActiveContract(contract);
	}
	
	public void HireSmuggler(Smuggler smuggler)
	{
		if (hiredSmugglers.Count >= MaxSmugglersLimit)
		{
			Debug.LogWarning("Max smugglers limit reached!");
			return;
		}

		Cash -= smuggler.hirePrice;
		hiredSmugglers.Add(smuggler);
	}

	public void BuyVehicle(Vehicle vehicle)
	{
		if (vehicles.Count >= MaxVehiclesLimit)
		{
			Debug.LogWarning("Max vehicles limit reached!");
			return;
		}

		Cash -= vehicle.price;
		vehicles.Add(vehicle);
	}
}