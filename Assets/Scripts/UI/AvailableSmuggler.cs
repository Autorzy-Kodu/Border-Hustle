using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvailableSmuggler : MonoBehaviour
{
	private Smuggler smuggler;

	[SerializeField] private TextMeshProUGUI fullNameText;
	[SerializeField] private Image portraitImage;
	[SerializeField] private TextMeshProUGUI hirePriceText;
	[SerializeField] private Transform smugglerTraitsParent;
	[SerializeField] private GameObject smugglerTraitPrefab;
	
	private void Awake()
	{
		smuggler = Smuggler.GenerateSmuggler();
		fullNameText.text = smuggler.fullName;
		portraitImage.sprite = smuggler.portrait;
		hirePriceText.text = $"{smuggler.hirePrice:0.00}zł";

		foreach (Trait trait in smuggler.traits)
		{
			TextMeshProUGUI smugglerTrait = Instantiate(smugglerTraitPrefab, smugglerTraitsParent.position, Quaternion.identity, smugglerTraitsParent).GetComponent<TextMeshProUGUI>();
			smugglerTrait.text = trait.traitName;
			smugglerTrait.color = trait.color;
		}
	}

	public void Hire()
	{
		GameManager.Instance.HireSmuggler(smuggler);
		Destroy(gameObject);
	}
	
	public void Reject()
	{
		Destroy(gameObject);
	}
}
