using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class Contract
{
	public string description;
	public float time;
	public float payment;
	public string organisation;
	public Dictionary<string, IntPair> goods = new ();

	public static Contract GenerateRandom()
	{
		Contract contract = new Contract();
		contract.description = contractsDescrptions[Random.Range(0, contractsDescrptions.Count)];
		contract.time = Random.Range(600f, 3600f);
		contract.organisation = GameData.Instance.organisationsData.GetRandom().organizationName;
		float nextGoodProbability = 1f;
		contract.payment = Random.Range(100f, 1000f);
		while (Random.Range (0f, 1f) < nextGoodProbability)
		{
			int amount = Random.Range(5, WarehouseManager.Instance.GetWarehouseCapacity());
			contract.goods.Add(GameData.Instance.goodsData.GetRandom().goodName, new IntPair(0, amount));
			contract.payment += amount * Random.Range(75f, 250f);
			nextGoodProbability *= nextGoodProbability;
		}
		return contract;
	}

	public void CheckCompletionAndGiveMoney()
	{
		string deliveredGoods = "Delivered goods: ";
		foreach (KeyValuePair<string, IntPair> goodPair in goods)
		{
			deliveredGoods += $"{goodPair.Key} => {goodPair.Value.item1}/{goodPair.Value.item2}";
		}
		Debug.Log(deliveredGoods);

		foreach (KeyValuePair<string, IntPair> goodPair in goods)
		{
			if (goodPair.Value.item1 != goodPair.Value.item2)
			{
				return;
			}
		}
		
		Debug.Log("Contract completed!");
		GameManager.Instance.Cash += payment;
		GameManager.Instance.RemoveContract(this);
	}

	public static List<string> contractsDescrptions = new List<string>() {
		"Ciężka dostawa tylko dla twardzieli!",
		"Tylko 1% ludzi potrafi wykonać tę dostawę!!!",
		"Gorący towar, potrzebna dostawa dopóki się sprzedaje",
		"Uczciwa zapłata za nieuczciwą pracę"
	};
}