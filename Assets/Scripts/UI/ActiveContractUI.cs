using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ActiveContractUI : MonoBehaviour
{
	[SerializeField] private TextMeshProUGUI contractText;
	[SerializeField] private TextMeshProUGUI priceText;
	[SerializeField] private TextMeshProUGUI timeText;
	
	public string Description
	{
		set => contractText.text = value;
	}

	public float Price
	{
		set => priceText.text = $"${value}";
	}

	public float Time
	{
		set => timeText.text = $"{value}";
	}
}
