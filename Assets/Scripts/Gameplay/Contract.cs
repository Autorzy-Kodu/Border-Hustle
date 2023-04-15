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
		goods.Add("chleb", new IntPair(0, 10));
		// TODO na jakiej zasadzie powinny generować się nowe losowe kontrakty?
	}
}