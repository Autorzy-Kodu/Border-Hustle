using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
	[SerializeField] private TextMeshProUGUI cashText;
    [SerializeField] private TextMeshProUGUI smugglerText;
    [SerializeField] private TextMeshProUGUI carText;
    [SerializeField] private TextMeshProUGUI boatText;
    [SerializeField] private TextMeshProUGUI planeText;
    [SerializeField] private Slider heatSlider;
	[SerializeField] private Transform activeContractsParent;
	[SerializeField] private GameObject activeContractPrefab;
	private Dictionary<Contract, GameObject> activeContractDictionary = new ();

	[SerializeField] private bool gamePaused;
	private void Start()
	{
		SetSmugglerText();
		SetCarText();
		SetPlaneText();
		SetBoatText();

    }
	public float Cash
	{
		set => cashText.text = $"{value:0.00}zł";
	}

	public float Heat
	{
		set => heatSlider.value = value;
	}
	public void SetSmugglerText()
	{
		smugglerText.text = $"{GameManager.Instance.hiredSmugglers.Count}/{GameManager.Instance.MaxSmugglersLimit}";
	}
    public void SetCarText()
    {
		int i = 0;
		foreach(Vehicle vehicle in GameManager.Instance.vehicles)
		{
			if(vehicle.type== VehicleType.Ground)
			{
				i++;
			}
		}
		carText.text = $"{i}/{GameManager.Instance.MaxVehiclesLimit}";
    }
    public void SetBoatText()
    {
        int i = 0;
        foreach (Vehicle vehicle in GameManager.Instance.vehicles)
        {
            if (vehicle.type == VehicleType.Water)
            {
                i++;
            }
        }
        boatText.text = $"{i}/{GameManager.Instance.MaxVehiclesLimit}";
    }
    public void SetPlaneText()
    {
        int i = 0;
        foreach (Vehicle vehicle in GameManager.Instance.vehicles)
        {
            if (vehicle.type == VehicleType.Air)
            {
                i++;
            }
        }
        planeText.text = $"{i}/{GameManager.Instance.MaxVehiclesLimit}";
    }

    public void AddActiveContract(Contract contract)
	{
		GameObject newContract = Instantiate(activeContractPrefab, transform.position, Quaternion.identity, activeContractsParent);
		activeContractDictionary.Add(contract, newContract);
		ActiveContractUI activeContractUI = newContract.GetComponent<ActiveContractUI>();
		activeContractUI.Description = contract.description;
		Debug.Log(activeContractDictionary.Count);
        RefreshActiveContract(contract);
    }

	public void RemoveActiveContract(Contract contract)
	{
		Debug.Log(activeContractDictionary.Count);
		Destroy(activeContractDictionary[contract].gameObject);
		activeContractDictionary.Remove(contract);
	}

	public void RefreshActiveContract(Contract contract)
	{
		activeContractDictionary[contract].GetComponent<ActiveContractUI>().Description = contract.description;
		int i = 0;
		foreach (KeyValuePair<string, IntPair> activeContract in contract.goods)
		{
			activeContractDictionary[contract].gameObject.transform.GetChild(i).GetComponent<Image>().sprite = GameData.Instance.goodsData.goodsDictionary[activeContract.Key].goodThumbnail;
			int def = 0;
			WarehouseManager.Instance.GetGoods().TryGetValue(activeContract.Key, out def);
            activeContractDictionary[contract].gameObject.transform.GetChild(i+1).GetComponent<TextMeshProUGUI>().text = $"{activeContract.Value.item1}/{activeContract.Value.item2} ({def})";
			i += 2;
        }
		while (i <= 5)
		{
			activeContractDictionary[contract].gameObject.transform.GetChild(i).gameObject.SetActive(false);
			i++;
        }

        }

	public void TogglePause()
	{
		GameManager.Instance.GameSpeed = gamePaused ? 1f : 0f;
		gamePaused = !gamePaused;
	}
}
