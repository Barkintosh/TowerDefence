using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public float money;

    public bool Buy(float price)
    {
        if(money >= price)
        {
            money -= price;
            return true;
        }
        Debug.Log("Not enough money!");
        return false;
    }

    public bool EnoughMoney(float price)
    {
        if(money >= price) return true;
        return false;
    }

    public void UpdateMoney(float value)
    {
        money += value;
    }
}
