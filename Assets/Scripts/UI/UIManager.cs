using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
	[SerializeField] private TextMeshProUGUI cashText;
	[SerializeField] private Slider heatSlider;
	[SerializeField] private Transform activeContractsParent;
	[SerializeField] private GameObject activeContractPrefab;
	
	public float Cash
	{
		set => cashText.text = $"${value:0.##}";
	}

	public float Heat
	{
		set => heatSlider.value = value;
	}

	public void AddActiveContract(Contract contract)
	{
		GameObject newContract = Instantiate(activeContractPrefab, transform.position, Quaternion.identity, activeContractsParent);
		ActiveContractUI activeContractUI = newContract.GetComponent<ActiveContractUI>();
		activeContractUI.Description = contract.description;
	}
}
