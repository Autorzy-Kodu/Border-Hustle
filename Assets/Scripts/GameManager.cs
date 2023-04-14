using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	private float cash;

	private List<Contract> activeContracts = new();
	private List<Smuggler> hiredSmugglers = new();
	
	public float Cash
	{
		get => cash;
		set {
			cash = value;
			UIManager.Instance.Cash = cash;
		}
	}
}