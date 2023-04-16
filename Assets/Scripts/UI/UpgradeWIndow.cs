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
    [SerializeField]
    TextMeshProUGUI warehouseUpgradePrice;
    int clickUpgradePrice = 10;
    int clickvalue = 5;

    private void Start()
    {
        goodText.text = $"Produkuj: {WarehouseManager.Instance.GetActiveGood()}";
        clickValueText.text = $"{clickvalue}na klikni�cie";
        priceText.text = $"{clickUpgradePrice:0.00}z�";
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
        goodText.text = $"Produkuj: {WarehouseManager.Instance.GetActiveGood()}";
    }

    public void UpdateClickValue()
    {
        if (GameManager.Instance.Cash >= clickUpgradePrice)
        {  
            clickValueText.text = $"{WarehouseManager.Instance.GetActualClickValue()} na klikni�cie";
            clickUpgradePrice *= 2;
            priceText.text = $"{clickUpgradePrice:0.00}z�";

        }
    }
    public void UpdateWarehousePrice()
    {
        warehouseUpgradePrice.text = $"{WarehouseManager.Instance.GetWarehouseUpgradePrice():0.00}z�";
    }

}
