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
	[SerializeField] private TextMeshProUGUI contractDescriptionText;
	[SerializeField] private TextMeshProUGUI contractTimeText;
	[SerializeField] private TextMeshProUGUI contractPaymentText;
	
	private void Start()
	{
		contract = Contract.GenerateRandom();
		contractDescriptionText.text = contract.description;
		contractTimeText.text = $"{contract.time}";
		contractPaymentText.text = $"{contract.payment:0.00}zł";
		organizationLogo.sprite = GameData.Instance.organisationsData.organisationsDictionary[contract.organisation].logo;
		StartCoroutine(ClockTick());
	}

	public void SetContract(Contract newContract)
	{
		contract = newContract;
		contractDescriptionText.text = contract.description;
		contractTimeText.text = $"{TimeSpan.FromSeconds(contract.time)}";
		contractPaymentText.text = $"{contract.payment:0.00}zł";
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

	IEnumerator ClockTick()
	{
		while (contract.time > 0)
		{
			contract.time--;
			contractTimeText.text = $"{TimeSpan.FromSeconds(contract.time)}";
			yield return new WaitForSeconds(1f);
		}
	}
}
