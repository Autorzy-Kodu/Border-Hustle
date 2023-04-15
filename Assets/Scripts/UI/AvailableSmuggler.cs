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
	[SerializeField] private Transform smugglerTraitsParent;
	[SerializeField] private GameObject smugglerTraitPrefab;

	private void Start()
	{
		smugglersData = GameData.Instance.smugglersData;
		smuggler = new Smuggler
		{
			fullName = smugglersData.GetRandomFullName(),
			portrait = smugglersData.GetRandomPortrait()
		};
		fullNameText.text = smuggler.fullName;
		portraitImage.sprite = smuggler.portrait;
		
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
