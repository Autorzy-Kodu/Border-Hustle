using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "GoodsData", menuName = "ScriptableObjects/GoodsData", order = 1)]
public class GoodsData : ScriptableObject
{
	public List<Good> goods;
    public Dictionary<string, Good> goodsDictionary = new();

    private void OnEnable()
    {
        goodsDictionary.Clear();
        foreach (Good g in goods)
        {
            goodsDictionary.Add(g.goodName, g);
        }
    }

    public Good GetRandom()
    {
        return goods[Random.Range(0, goods.Count)];
    }
}