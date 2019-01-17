using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [Header("Referencies")]
    public TowerInterface towerInterface;
    public HealthInterface healthInterface;
    public ShopInterface shopInterface;
    [Header("Settings")]
    public float refresh = 0.1f;
    public float boxesSpacing = 10f;
    float timer;

    void Update()
    {
        if(Time.time > timer)
        {
            healthInterface.UpdateInterface();
            shopInterface.UpdateInterface();
            //towerInterface.UpdateInterface();

            timer = Time.time + refresh;
        }
    }
}
