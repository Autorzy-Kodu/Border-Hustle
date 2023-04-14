using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
	private TextMeshProUGUI cashText;
	
	public float Cash
	{
		set => cashText.text = $"${value}";
	}
}
