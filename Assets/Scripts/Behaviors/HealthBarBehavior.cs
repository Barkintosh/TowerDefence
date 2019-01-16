using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehavior : MonoBehaviour
{
    public GameObject visual;
    public RectTransform self;
    public RectTransform bar;
    public Text text;
    public bool taken = false;

    public void Awake()
    {
        self = GetComponent<RectTransform>();
    }

    public void Show()
    {
        taken = true;
        visual.SetActive(true);
    }

    public void SetBar(float currentHealth, float maxHealth, Vector3 pos)
    {
        self.position = Camera.main.WorldToScreenPoint(pos);
        bar.sizeDelta = new Vector2( 100*(currentHealth / maxHealth), bar.sizeDelta.y);
        text.text = currentHealth.ToString() + " / " + maxHealth.ToString();
    }

    public void Hide()
    {
        taken = false;
        visual.SetActive(false);
    }
}
