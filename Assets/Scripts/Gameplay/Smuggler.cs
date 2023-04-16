using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = Unity.Mathematics.Random;

[Serializable]
public class Smuggler
{
	public string fullName;
	public float hirePrice;
	[Range(0f, 1f)] public float paymentPercent; 
	[Range (0f, 1f)] public float tiredness;
	public Dictionary<BorderCrossing.Type, float> experience = new ();
	public List<Trait> traits = new ();
	public float susMeter;
	public Sprite portrait;

	public static Smuggler GenerateSmuggler()
	{
		SmugglersData smugglersData = GameData.Instance.smugglersData;
		Smuggler smuggler = new Smuggler();
		// losowe nie ważne
		smuggler.fullName = smugglersData.GetRandomFullName();
		smuggler.portrait = smugglersData.GetRandomPortrait();
		// losowe ważne
		float traitProbability = 0.35f;
		while (UnityEngine.Random.Range (0f, 1f) < traitProbability)
		{
			smuggler.traits.Add(GameData.Instance.traitsData.GetRandomTrait());
			traitProbability *= 0.34f;
		}

		smuggler.susMeter = UnityEngine.Random.Range(0.01f, 0.3f);
		// jakoś obliczane
		smuggler.hirePrice = 500;
		foreach (Trait trait in smuggler.traits)
		{
			if (trait.type == Trait.Type.Positive)
				smuggler.hirePrice += UnityEngine.Random.Range(150f, 350f);
			else if (trait.type == Trait.Type.Negative)
				smuggler.hirePrice += UnityEngine.Random.Range(-50f, -150f);
			else
				smuggler.hirePrice += UnityEngine.Random.Range(-50f, 50f);
		}
		
		smuggler.hirePrice *= 1f - smuggler.susMeter;
		smuggler.paymentPercent = UnityEngine.Random.Range(0.2f, 5f);
		return smuggler;
	}
}
