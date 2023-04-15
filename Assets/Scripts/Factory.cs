using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour, IClickable
{
	private string randomGoodName;
	public void Click()
	{
        randomGoodName = GameData.Instance.goodsData.goods[Random.Range(
			0, GameData.Instance.goodsData.goods.Count)].goodName;
		WarehouseManager.Instance.AddGoods(randomGoodName, Random.Range(0,100));
    }
}
