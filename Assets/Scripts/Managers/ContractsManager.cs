using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContractsManager : MonoBehaviour
{
	[SerializeField] private GameObject newContractPrefab;
	[SerializeField] private int availableContracts = 3;

	private void Awake()
	{
		FailSafe();
		GenerateContracts();
	}
	
	private void Start()
	{
		StartCoroutine(EAddNewContracts());
	}

	public void FailSafe()
	{
		GameObject firstContractGO = Instantiate(newContractPrefab, transform.position, Quaternion.identity, transform);
		AvailableContract availableContract = firstContractGO.GetComponent<AvailableContract>();
		Contract firstContract = new Contract();
		firstContract.description = "Mój pierwszy kontrakt";
		firstContract.organisation = GameData.Instance.organisationsData.GetRandom().organizationName;
		firstContract.goods.Add(GameData.Instance.goodsData.GetRandom().goodName, new IntPair(0, 5));
		firstContract.time = 9999999;
		firstContract.payment = 499.99f;
		availableContract.SetContract(firstContract);
	}
	
	public void GenerateContracts()
	{
		while (transform.childCount < availableContracts)
		{
			// TODO wygeneruj losowy kontrakt
			Instantiate(newContractPrefab, transform.position, Quaternion.identity, transform);
		}
	}
	
	IEnumerator EAddNewContracts()
	{
		while (true)
		{
			GenerateContracts();
			yield return new WaitForSeconds(UnityEngine.Random.Range(45f, 60f));
		}
	}
}