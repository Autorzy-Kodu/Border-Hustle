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
	public Dictionary<string, IntPair> goods;

	public void GenerateRandom()
	{
		description = "Lorem ipsum";
		time = UnityEngine.Random.Range(10f, 360f);
		payment = UnityEngine.Random.Range(1000f, 100000f);
		organisation = "Wyznawcy Chleba";
		// TODO na jakiej zasadzie powinny generować się nowe losowe kontrakty?
	}
}