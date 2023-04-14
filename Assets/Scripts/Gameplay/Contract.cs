using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contract
{
	public string description;
	public float time;
	public float payment;

	public void GenerateRandom()
	{
		description = "Lorem ipsum";
		// TODO na jakiej zasadzie powinny generować się nowe losowe kontrakty?
	}
}