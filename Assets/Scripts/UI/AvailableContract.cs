using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvailableContract : MonoBehaviour
{
	private Contract contract;
	[SerializeField] private Image organizationLogo;
	[SerializeField] private TextMeshProUGUI contractTimeText;
	[SerializeField] private TextMeshProUGUI contractPaymentText;
	
	private void Start()
	{
		contract = new Contract();
		contract.GenerateRandom();
		contractTimeText.text = $"{contract.time}";
		contractPaymentText.text = $"{contract.payment}zł";
		organizationLogo.sprite = GameData.Instance.organisationsData.organisationsDictionary[contract.organisation].logo;
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
