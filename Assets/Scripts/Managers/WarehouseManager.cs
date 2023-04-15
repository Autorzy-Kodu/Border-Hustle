using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WarehouseManager : Singleton<WarehouseManager>
{
    Dictionary<string, int> warehouse = new Dictionary<string, int>();
    int warehouseCapacity=50;
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
    public int TakeGoods(string good, int value)
    {
        if (warehouse.ContainsKey(good))
        {
            warehouse[good] -= value;
            if (warehouse[good] < 0)
            {
	            value += warehouse[good];
	            warehouse[good] = 0;
            }

            Debug.Log("Removed: " + value + " " + good);
            return value;
        }
        return 0;
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
}
