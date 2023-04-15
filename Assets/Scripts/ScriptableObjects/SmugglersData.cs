using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SmugglersData", menuName = "ScriptableObjects/SmugglersData", order = 1)]
public class SmugglersData : ScriptableObject
{
	public List<string> smugglersNames;
	public List<string> smugglersLastNames;
	public List<Sprite> smugglersPortraits;
}