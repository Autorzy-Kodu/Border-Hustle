using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Factory : MonoBehaviour, IClickable
{
	[SerializeField]
	private TextMeshPro valueOnUi;
	[SerializeField]
	private Transform textPosition;
	[SerializeField]
	private Image icon;
    [SerializeField] 
    private Window windowToShow;

    Vector3 textStartPosition;
    private string pickedGoodName;
	private Color textColor;
	private Color iconColor;
    List<string> goodName = new List<string>();
    int clickUpgradePrice = 10;
    int clickvalue=5;
    private int actualClickvalue;
    private void Start()
	{
		textStartPosition = textPosition.position;
		textColor = valueOnUi.color;
        iconColor = icon.color;
		iconColor.a = 0f;
		icon.color = iconColor;
        
        foreach (Good good in GameData.Instance.goodsData.goods)
        {
            goodName.Add(good.goodName);
        }
        WarehouseManager.Instance.SetActiveGood(goodName[0]);
        pickedGoodName = WarehouseManager.Instance.GetActiveGood();
        WarehouseManager.Instance.SetActualClickValue(clickvalue);
    }
	public void Click()
	{
        Debug.Log(pickedGoodName);
        pickedGoodName= WarehouseManager.Instance.GetActiveGood();
        Debug.Log(pickedGoodName);
        if (WarehouseManager.Instance.GetGoods().ContainsKey(pickedGoodName) && WarehouseManager.Instance.GetGoods()[pickedGoodName] >= WarehouseManager.Instance.GetWarehouseCapacity())
		{
            textColor.a = 1;
            iconColor.a = 1;
            textPosition.position = textStartPosition;
            valueOnUi.text = "Magazyn Pe³ny!!!";
            StartCoroutine(FlyText());
        }
		else
		{
            textPosition.position = textStartPosition;
            textColor.a = 1;
            iconColor.a = 1;
            valueOnUi.color = textColor;
            icon.color = iconColor;
            actualClickvalue = Random.Range(0, clickvalue);
            valueOnUi.text = actualClickvalue.ToString();
            icon.sprite = GameData.Instance.goodsData.goodsDictionary[pickedGoodName].goodThumbnail;
            StartCoroutine(FlyText());
            WarehouseManager.Instance.AddGoods(pickedGoodName, actualClickvalue);
        }
        
    }
    public void RightClick()
    {
        Debug.Log("Building selected");
        if (!windowToShow)
        {
            Debug.LogWarning("WindowToShow not set for that building!");
            return;
        }
        windowToShow.Show();
    }
	private IEnumerator FlyText()
	{
		for(int i = 0; i <= 60; i++) { 
			textPosition.position += new Vector3(0, 10f) * Time.deltaTime;
            textColor.a -= 0.02f;
			iconColor.a -= 0.02f;
			valueOnUi.color = textColor;
			icon.color = iconColor;
            yield return null;
        }
    }
    public void SetGoodName()
    {
        pickedGoodName = WarehouseManager.Instance.GetActiveGood();
    }
    public void OnChangeDropDown(TMP_Dropdown change)
    {
        WarehouseManager.Instance.SetActiveGood(goodName[change.value]);
    }
    public void UpgradeClickValue()
    {
        if (GameManager.Instance.Cash >= clickUpgradePrice)
        {
            GameManager.Instance.Cash -= clickUpgradePrice;
            clickUpgradePrice *= 2;
            clickvalue++;
            WarehouseManager.Instance.SetActualClickValue(clickvalue);
        }
    }
    IEnumerator AutoClicker()
    {
        while (true) 
        {
            if (WarehouseManager.Instance.GetGoods().ContainsKey(pickedGoodName) && WarehouseManager.Instance.GetGoods()[pickedGoodName] >= WarehouseManager.Instance.GetWarehouseCapacity())
            {

            }
            else
            {
                Click();
            }
            yield return new WaitForSeconds(5);
        }
    }
    public void RunAutoClicker()
    {
        StartCoroutine(AutoClicker());
    }
}
