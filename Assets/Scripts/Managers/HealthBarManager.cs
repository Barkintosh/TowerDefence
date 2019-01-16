using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarManager : MonoBehaviour
{
    public GameObject healthBarPrefab;
    public List<HealthBarBehavior> activeHealthBars = new List<HealthBarBehavior>();

    public HealthBarBehavior GetBar()
    {
        foreach(HealthBarBehavior bar in activeHealthBars)
        {
            if(!bar.taken) return bar;
        }
        HealthBarBehavior newBar = Instantiate(healthBarPrefab, Vector3.zero, Quaternion.identity).GetComponent<HealthBarBehavior>();
        newBar.transform.SetParent(transform);  
        activeHealthBars.Add(newBar);
        return newBar;
    }
}