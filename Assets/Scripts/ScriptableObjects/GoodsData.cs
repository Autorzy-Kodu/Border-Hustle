using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GoodsData", menuName = "ScriptableObjects/GoodsData", order = 1)]
public class GoodsData : ScriptableObject
{
	public List<Good> goods;
}