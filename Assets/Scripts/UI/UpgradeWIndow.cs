using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeWIndow : Window
{
    [SerializeField]
    TMP_Dropdown dropdown;
    [SerializeField] 
    TextMeshProUGUI goodText;
    [SerializeField]
    TextMeshProUGUI priceText;
    [SerializeField]
    TextMeshProUGUI clickValueText;
    int clickUpgradePrice = 10;
    int clickvalue = 5;
    
    private void Start()
    {
        goodText.text = WarehouseManager.Instance.GetActiveGood();
        clickValueText.text = clickvalue.ToString();
        priceText.text = clickUpgradePrice.ToString();
        dropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        foreach (Good good in GameData.Instance.goodsData.goods)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData
            {
                text = good.goodName,
                image = good.goodThumbnail
            };  
            options.Add(optionData);
        }
        dropdown.AddOptions(options);
    }
    public void UpdateText()
    {
        goodText.text = WarehouseManager.Instance.GetActiveGood();
    }

    public void UpdateClickValue()
    {
        if (GameManager.Instance.Cash >= clickUpgradePrice)
        {  
            clickValueText.text = WarehouseManager.Instance.GetActualClickValue().ToString();
            clickUpgradePrice *= 2;
            priceText.text = clickUpgradePrice.ToString();

        }
    }

}
