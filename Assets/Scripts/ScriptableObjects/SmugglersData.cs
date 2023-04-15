using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SmugglersData", menuName = "ScriptableObjects/SmugglersData", order = 1)]
public class SmugglersData : ScriptableObject
{
	public List<string> smugglersNames;
	public List<string> smugglersLastNames;
	public List<Sprite> smugglersPortraits;

	public string GetRandomFullName()
	{
		return $"{smugglersNames[Random.Range(0, smugglersNames.Count)]} {smugglersLastNames[Random.Range(0, smugglersLastNames.Count)]}";
	}

	public Sprite GetRandomPortrait()
	{
		return smugglersPortraits[Random.Range(0, smugglersPortraits.Count)];
	}
}