using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableContract : MonoBehaviour
{
	private Contract contract;
	
	private void Awake()
	{
		contract = new Contract();
		contract.GenerateRandom();
	}

	// TODO aktywowane przyciskiem na obiekcie
	public void AcceptContract()
	{
		GameManager.Instance.AddContract(contract);
		Destroy(gameObject);
	}

	// TODO aktywowane przyciskiem na obiekcie
	public void RejectContract()
	{
		Destroy(gameObject);
	}
}
