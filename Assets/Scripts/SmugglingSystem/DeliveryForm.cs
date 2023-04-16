using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeliveryForm : Window
{
    [SerializeField] private TMP_Dropdown contractDropdown;
    [SerializeField] private TMP_Dropdown roadDropdown;
    [SerializeField] private TMP_Dropdown smugglersDropdown;
    [SerializeField] private TMP_Dropdown vehicleDropdown;
    [SerializeField] private TMP_Dropdown wrappingDropdown;
    [SerializeField] private TextMeshProUGUI deliveryCostsText;
    [SerializeField] private TextMeshProUGUI estimatedEarningsText;
    [SerializeField] private Button sendButton;

    private void Start()
    {
        roadDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        options.Add(new TMP_Dropdown.OptionData
        {
            text = "Wybierz drogę"
        });
        foreach (Road road in Map.Instance.roads)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData
            {
                text = road.roadName,
                image = road.sprite
            };
            options.Add(optionData);
        }
        roadDropdown.AddOptions(options);
    }

    public override void Hide()
    {
        base.Hide();

        Transform tirednessPanel = smugglersDropdown.transform.GetChild(4);
        tirednessPanel.gameObject.SetActive(false);

        Transform conditionPanel = vehicleDropdown.transform.GetChild(4);
        conditionPanel.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GenerateContracts();
        GenerateSmugglers();
        GenerateVehicles();
        GenerateWrappings();

        CalculateDelivery();
    }

    public void GenerateContracts()
    {
        contractDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        options.Add(new TMP_Dropdown.OptionData
        {
            text = "Wybierz kontrakt"
        });
        foreach (Contract contract in GameManager.Instance.activeContracts)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData
            {
                text = contract.description,
                image = GameData.Instance.organisationsData.organisationsDictionary[contract.organisation].logo
            };
            options.Add(optionData);
        }
        contractDropdown.AddOptions(options);
    }

    public void SetContract(TMP_Dropdown change)
    {
        Contract contract = GameManager.Instance.activeContracts[contractDropdown.value - 1];

        var labelText = contractDropdown.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        labelText.text = contract.description;

        labelText.text += "<br><font-weight=300><size=11>";
        labelText.text += contract.organisation;

        var goodsText = contractDropdown.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        goodsText.text = "";

        foreach (var good in contract.goods)
        {
            goodsText.text += good.Key + ": " + good.Value.item1 + " kg / " + good.Value.item2 + " kg<br>";
        }

        var timeAndPaymentText = contractDropdown.transform.GetChild(4).GetComponent<TextMeshProUGUI>();
        timeAndPaymentText.text = "<line-height=24>" + contract.time + " dni<size=32><br></size><color=#29cc47>" + contract.payment + " zł";


        CalculateDelivery();
    }

    public void GenerateSmugglers()
    {
        smugglersDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        options.Add(new TMP_Dropdown.OptionData
        {
            text = "Wybierz przemytnika"
        });
        foreach (Smuggler smuggler in GameManager.Instance.hiredSmugglers)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData
            {
                text = smuggler.fullName,
                image = smuggler.portrait
            };
            options.Add(optionData);
        }

        smugglersDropdown.AddOptions(options);
    }

    public void SetSmuggler(TMP_Dropdown change)
    {
        Smuggler smuggler = GameManager.Instance.hiredSmugglers[smugglersDropdown.value - 1];

        var traitText = smugglersDropdown.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        traitText.text = "<font-weight=300>";

        foreach (var trait in smuggler.traits)
        {
            traitText.text += "<color=#" + ColorUtility.ToHtmlStringRGB(trait.color) + ">";
            traitText.text += trait.traitName + " -";

            if (trait.susMultiplier != 1f)
                traitText.text += " Podejrzliwość: " + trait.susMultiplier + "x";

            if (trait.costMultiplier != 1f)
                traitText.text += " Koszt: " + trait.costMultiplier + "x";

            if (trait.sellMultiplier != 1f)
                traitText.text += " Zysk: " + trait.sellMultiplier + "x";

            if (trait.escapeMultiplier != 1f)
                traitText.text += " Szansa ucieczki: " + trait.escapeMultiplier + "x";

            if (trait.speedMultiplier != 1f)
                traitText.text += " Szybkość: " + trait.speedMultiplier + "x";

            traitText.text += "<br>";
        }

        Transform tirednessPanel = smugglersDropdown.transform.GetChild(4);
        tirednessPanel.gameObject.SetActive(true);

        Slider tirednessSlider = tirednessPanel.GetComponent<Slider>();
        tirednessSlider.value = smuggler.tiredness;

        Image tirednessFill = tirednessPanel.GetChild(1).GetChild(0).GetComponent<Image>();
        tirednessFill.color = Color.Lerp(Color.green, Color.red, tirednessSlider.value / tirednessSlider.maxValue);

        CalculateDelivery();
    }

    public void SetRoad(TMP_Dropdown change)
    {
        CalculateDelivery();
    }

    public void GenerateVehicles()
    {
        vehicleDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        options.Add(new TMP_Dropdown.OptionData
        {
            text = "Wybierz pojazd"
        });
        foreach (Vehicle vehicle in GameManager.Instance.vehicles)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData
            {
                text = vehicle.vehicleName,
                image = vehicle.thumbnail
            };
            options.Add(optionData);
        }

        vehicleDropdown.AddOptions(options);
    }

    public void SetVehicle(TMP_Dropdown change)
    {
        Vehicle vehicle = GameManager.Instance.vehicles[vehicleDropdown.value - 1];

        var vehicleText = vehicleDropdown.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        vehicleText.text = vehicle.vehicleName + "<br><font-weight=300><size=11>";

        switch (vehicle.type)
        {
            case VehicleType.Ground:
                vehicleText.text += "Pojazd lądowy";
                break;
            case VehicleType.Air:
                vehicleText.text += "Samolot";
                break;
            case VehicleType.Water:
                vehicleText.text += "Łódź";
                break;
        }

        var vehicleStatsText = vehicleDropdown.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        vehicleStatsText.text = "Ładowność: <font-weight=300>" + vehicle.capacity + " kg</font-weight><br>";
        vehicleStatsText.text += "Prędkość: <font-weight=300>" + vehicle.speed + " km / h</font-weight>";

        Transform conditionPanel = vehicleDropdown.transform.GetChild(4);
        conditionPanel.gameObject.SetActive(true);

        Slider conditionSlider = conditionPanel.GetComponent<Slider>();
        conditionSlider.value = vehicle.durability;

        Image conditionFill = conditionPanel.GetChild(1).GetChild(0).GetComponent<Image>();
        conditionFill.color = Color.Lerp(Color.red, Color.green, conditionSlider.value / conditionSlider.maxValue);

        CalculateDelivery();
    }

    public void GenerateWrappings()
    {
        wrappingDropdown.ClearOptions();
        List<TMP_Dropdown.OptionData> options = new List<TMP_Dropdown.OptionData>();
        options.Add(new TMP_Dropdown.OptionData
        {
            text = "Wybierz sposób przewozu"
        });
        foreach (Wrapping wrapping in GameData.Instance.wrappingsData.wrappings)
        {
            TMP_Dropdown.OptionData optionData = new TMP_Dropdown.OptionData
            {
                text = wrapping.wrappingName
            };
            options.Add(optionData);
        }

        wrappingDropdown.AddOptions(options);
    }

    public void SetWrapping(TMP_Dropdown change)
    {
        float susMeter = GameData.Instance.wrappingsData.wrappings[wrappingDropdown.value - 1].susMeter;
        float cost = GameData.Instance.wrappingsData.wrappings[wrappingDropdown.value - 1].price;
        String wrappingName = GameData.Instance.wrappingsData.wrappings[wrappingDropdown.value - 1].wrappingName;

        var wrappingText = wrappingDropdown.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        wrappingText.text = wrappingName;

        var wrappingStatsText = wrappingDropdown.transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        wrappingStatsText.text = "<line-height=24>Szansa wykrycia: <font-weight=300>+" + susMeter + " %</font-weight><br>";
        wrappingStatsText.text += "Koszt: <font-weight=300>+" + cost + " za szt.</font-weight><br>";

        CalculateDelivery();
    }

    void CalculateDelivery()
    {
        sendButton.interactable = false;
        float cost = 0f;
        float income = 0f;
        bool canSend = true;

        float contractPayment = 0;
        if (contractDropdown.value > 0)
            contractPayment = GameManager.Instance.activeContracts[contractDropdown.value - 1].payment;
        else
            canSend = false;

        float smugglerPayment = 0;
        if (smugglersDropdown.value > 0)
            smugglerPayment = GameManager.Instance.hiredSmugglers[smugglersDropdown.value - 1].paymentPercent * contractPayment;
        else
            canSend = false;

        float vehicleExploatationCost = 0;
        if (vehicleDropdown.value > 0)
            vehicleExploatationCost = GameManager.Instance.vehicles[vehicleDropdown.value - 1].exploatationCost;
        else
            canSend = false;

        float wrappingPrice = 0;
        if (wrappingDropdown.value > 0)
            wrappingPrice = GameData.Instance.wrappingsData.wrappings[wrappingDropdown.value - 1].price;
        else
            canSend = false;

        income += contractPayment;
        cost -= smugglerPayment;
        cost -= vehicleExploatationCost;
        cost -= wrappingPrice;

        deliveryCostsText.text = $"{cost:0.00}zł";
        estimatedEarningsText.text = $"+{income:0.00}zł";

        if (canSend)
            sendButton.interactable = true;
    }

    public void Send()
    {
        IllegalTransport illegalTransport = new IllegalTransport();

        illegalTransport.contract = GameManager.Instance.activeContracts[contractDropdown.value - 1];
        illegalTransport.smuggler = GameManager.Instance.hiredSmugglers[smugglersDropdown.value - 1];
        illegalTransport.vehicle = GameManager.Instance.vehicles[vehicleDropdown.value - 1];
        illegalTransport.wrapping = GameData.Instance.wrappingsData.wrappings[wrappingDropdown.value - 1];
        // TODO pobierz z magazynu
        foreach (KeyValuePair<string, IntPair> goodPair in illegalTransport.contract.goods)
        {
            int itemsTaken = WarehouseManager.Instance.TakeGoods(goodPair.Key, goodPair.Value.item2);
            illegalTransport.goods.Add(goodPair.Key, itemsTaken);
            illegalTransport.vehicle.capacity -= itemsTaken;
            Debug.Log($"taken {goodPair.Key} {itemsTaken} items");
        }

        // TODO sprawdzenie czy cokolwiek zapakowaliśmy

        GameManager.Instance.hiredSmugglers.Remove(illegalTransport.smuggler);
        GameManager.Instance.vehicles.Remove(illegalTransport.vehicle);
        Map.Instance.roads[roadDropdown.value - 1].SmuggleUsingThisRoad(illegalTransport.vehicle.prefab, illegalTransport);
        Hide();
    }
}