using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IllegalTransport
{
	public Contract contract;
	public Smuggler smuggler;
	public Vehicle vehicle;
	public Wrapping wrapping;
	public Dictionary<string, int> goods = new ();

	public float CalculateSusPercent()
	{
		// TODO napisać formułę liczącą
		
		float sus = 0f;

		sus += wrapping.susMeter;
		
		foreach (Trait trait in smuggler.traits)
		{
			sus *= trait.susMultiplier;
		}

		return sus;
	}
}
