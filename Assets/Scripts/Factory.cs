using System.Collections;
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

    Vector3 textStartPosition;
	float disapearTimer=1f;
    private string randomGoodName;
    private int valueOfGoods;
	private Color textColor;
	private Color iconColor;

    private void Start()
	{
		textStartPosition = textPosition.position;
		textColor = valueOnUi.color;
        iconColor = icon.color;
		iconColor.a = 0f;
		icon.color = iconColor;
    }
	public void Click()
	{
		textPosition.position = textStartPosition;
		textColor.a = 1;
        iconColor.a = 1;
        valueOnUi.color = textColor;
		icon.color = iconColor;
        valueOfGoods = Random.Range(0, 100);
		valueOnUi.text = valueOfGoods.ToString();
		Good good = GameData.Instance.goodsData.goods[Random.Range(
			0, GameData.Instance.goodsData.goods.Count)];
        randomGoodName = good.goodName;
		icon.sprite = good.goodThumbnail;
        StartCoroutine(FlyText());
        WarehouseManager.Instance.AddGoods(randomGoodName, valueOfGoods);
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
}
