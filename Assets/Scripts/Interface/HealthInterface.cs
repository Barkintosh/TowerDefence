using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthInterface : MonoBehaviour
{
    public RectTransform bar;
    public RectTransform healthBar;
    public TextMeshProUGUI healthText;
    float oHealth;
    float cHealth;

    void Start()
    {
        oHealth = GameManager.instance.systemManager.health;
    }

    public void UpdateInterface()
    {
        Debug.Log("Yo");
        if(cHealth != GameManager.instance.systemManager.health)
        {
            cHealth = GameManager.instance.systemManager.health;
            healthBar.sizeDelta = new Vector2(cHealth/oHealth * bar.sizeDelta.x, bar.sizeDelta.y);
            healthBar.transform.localPosition = new Vector2(healthBar.sizeDelta.x/2, -bar.sizeDelta.y/2);
            healthText.text = cHealth + " / " + oHealth;
        }
    }
}
