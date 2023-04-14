using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
	private TextMeshProUGUI cashText;
	private Slider heatSlider;
	
	public float Cash
	{
		set => cashText.text = $"${value}";
	}

	public float Heat
	{
		set => heatSlider.value = value;
	}
}
