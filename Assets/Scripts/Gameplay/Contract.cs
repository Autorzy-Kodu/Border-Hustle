using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Contract
{
	public string description;
	public float time;
	public float payment;
	public string organisation;
	public Dictionary<string, IntPair> goods = new ();

	public void GenerateRandom()
	{
		description = "Lorem ipsum";
		time = UnityEngine.Random.Range(10f, 360f);
		payment = UnityEngine.Random.Range(1000f, 100000f);
		organisation = "Wyznawcy Chleba";
		goods.Add("Chleb", new IntPair(0, 10));
		// TODO na jakiej zasadzie powinny generować się nowe losowe kontrakty?
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
}