using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WrappingsData", menuName = "ScriptableObjects/WrappingsData", order = 1)]
public class WrappingsData : ScriptableObject
{
	public List<Wrapping> wrappings;
}