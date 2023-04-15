using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WarehouseWindow : Window
{
    [SerializeField] private GameObject newGoodPrefab;
    [SerializeField] private Transform newGoodParent;
    Dictionary<string,GameObject> goodUi = new Dictionary<string,GameObject>();

    private void OnEnable()
    {
        foreach (KeyValuePair<string,int> good in WarehouseManager.Instance.GetGoods())
        {
            if (!goodUi.ContainsKey(good.Key))
                goodUi.Add(good.Key, Instantiate(newGoodPrefab, transform.position, Quaternion.identity, newGoodParent));

            goodUi[good.Key].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = good.Key;
            goodUi[good.Key].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = good.Value.ToString();
            goodUi[good.Key].transform.GetChild(2).GetComponent<Image>().sprite = GameData.Instance.goodsData.goodsDictionary[good.Key].goodThumbnail;
        }
    }
}
