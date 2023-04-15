using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WarehouseManager : Singleton<WarehouseManager>
{
    Dictionary<string, int> warehouse = new Dictionary<string, int>();

    public void AddGoods(string good,int value)
    {
        if (warehouse.ContainsKey(good))
        {
            warehouse[good] += value;
            Debug.Log("Added: " + value + " " + good);
        }
        else
        {
            warehouse.Add(good, value);
            Debug.Log("Added: " + value + " " + good);
        }
        Debug.Log("W magazynie: "+warehouse[good]);
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
}
