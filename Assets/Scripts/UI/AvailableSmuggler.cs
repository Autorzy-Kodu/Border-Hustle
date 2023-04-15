using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AvailableSmuggler : MonoBehaviour
{
	private Smuggler smuggler;
	private SmugglersData smugglersData;

	[SerializeField] private TextMeshProUGUI fullNameText;
	[SerializeField] private Image portraitImage;
	[SerializeField] private TextMeshProUGUI hirePriceText;
	[SerializeField] private Transform smugglerTraitsParent;
	[SerializeField] private GameObject smugglerTraitPrefab;

	// TODO tylko debug
	private void Start()
	{
		smugglersData = GameData.Instance.smugglersData;
		smuggler = new Smuggler
		{
			fullName = smugglersData.GetRandomFullName(),
			portrait = smugglersData.GetRandomPortrait(),
			hirePrice = 100,
			paymentPercent = 0.1f
		};
		fullNameText.text = smuggler.fullName;
		portraitImage.sprite = smuggler.portrait;
		hirePriceText.text = $"{smuggler.hirePrice}zł";

		smuggler.traits.Add(GameData.Instance.traitsData.traits[0]);

		foreach (Trait trait in smuggler.traits)
		{
			TextMeshProUGUI smugglerTrait = Instantiate(smugglerTraitPrefab, smugglerTraitsParent.position, Quaternion.identity, smugglerTraitsParent).GetComponent<TextMeshProUGUI>();
			smugglerTrait.text = trait.traitName;
			smugglerTrait.color = trait.color;
		}
	}

	// TODO aktywowane przyciskami z zewnątrz
	public void Hire()
	{
		GameManager.Instance.HireSmuggler(smuggler);
		Destroy(gameObject);
	}
	
	// TODO aktywowane przyciskami z zewnątrz
	public void Reject()
	{
		Destroy(gameObject);
	}
}
