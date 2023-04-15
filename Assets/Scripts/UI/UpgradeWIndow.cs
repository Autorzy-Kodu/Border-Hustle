using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class UpgradeWIndow : Window
{
    [SerializeField]
    TMP_Dropdown dropdown;
    [SerializeField] 
    TextMeshProUGUI goodText;
    List<string> goodName = new List<string>();
    private void OnEnable()
    {
        foreach (Good good in GameData.Instance.goodsData.goods)
        {
            goodName.Add(good.goodName);
        }
    }
    public void OnChangeDropDown(TMP_Dropdown change)
    {

        goodText.text = goodName[change.value];
    }

    //List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
    //foreach (Road road in Map.Instance.roads)
    //{
    //    TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData
    //    {
    //        text = road.roadName,
    //        image = road.sprite
    //    };
    //    options.Add(optionData);
    //}
    //roadDropdown.AddOptions(options);
}
