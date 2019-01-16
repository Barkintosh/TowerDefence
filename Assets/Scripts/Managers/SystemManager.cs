using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemManager : MonoBehaviour
{
    public float health;

    public void UpdateHealth(float value)
    {
        health += value;
        if(health <= 0f)
        {
            Loose();
        }
    }

    void Loose()
    {

    }

    void Win()
    {

    }
}
