using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TraitsData", menuName = "ScriptableObjects/TraitsData", order = 1)]
public class TraitsData : ScriptableObject
{
	public List<Trait> traits;

	public Trait GetRandomTrait()
	{
		return traits[Random.Range(0, traits.Count)];
	}
}