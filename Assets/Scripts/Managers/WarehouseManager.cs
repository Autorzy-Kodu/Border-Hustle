using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WarehouseManager : Singleton<WarehouseManager>
{
    Dictionary<string, int> warehouse = new Dictionary<string, int>();
    int warehouseCapacity=50;
    string activeGoodName;
    int actualClickValue;
    public void AddGoods(string good,int value)
    {
        if (!warehouse.ContainsKey(good))
        {
            warehouse.Add(good, 0);
        }
        warehouse[good] += value;
        if (warehouse[good] > warehouseCapacity)
        {
            warehouse[good] = warehouseCapacity;
            Debug.Log("Added: " + value + " " + good);
        }       
        Debug.Log("W magazynie: " + warehouse[good]);
    }
    public void TakeGoods(string good, int value)
    {
        if (warehouse.ContainsKey(good) && warehouse[good] >= value)
        {
            warehouse[good] -= value;
            Debug.Log("Removed: " + value + " " + good);
        }
    }
    public Dictionary<string, int> GetGoods()
    {
            return warehouse;
    }
    public void SetWarehouseCapacity(int value)
    {
        warehouseCapacity = value;
    }
    public int GetWarehouseCapacity()
    {
        return warehouseCapacity;
    }
    public void SetActiveGood(string name)
    {
        activeGoodName = name;
    }
    public string GetActiveGood()
    {
        return activeGoodName;
    }

    public void SetActualClickValue(int name)
    {
        actualClickValue = name;
    }
    public int GetActualClickValue()
    {
        return actualClickValue;
    }
}
