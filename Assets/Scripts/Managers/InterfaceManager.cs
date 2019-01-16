using UnityEngine;

public class InterfaceManager : MonoBehaviour
{
    [Header("Referencies")]
    public TowerBoxBehavior towerBoxBehavior;
    public HealthInterface healthInterface;
    public ShopInterface shopInterface;
    [Header("Settings")]
    public float refresh = 0.1f;
    float timer;

    void Update()
    {
        if(Time.time > timer)
        {
            healthInterface.UpdateInterface();
            shopInterface.UpdateInterface();

            timer = Time.time + refresh;
        }
    }
}
