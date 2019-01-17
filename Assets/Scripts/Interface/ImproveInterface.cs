using UnityEngine;
using UnityEngine.UI;

public class ImproveInterface : MonoBehaviour
{
    public RectTransform self;
    public Text priceText;
    //public Button button;
    public WeaponBehavior weapon;

    public void ChangePrice(float price)
    {
        priceText.text = price.ToString();
    }

    public void Improve()
    {
        weapon.tower.BuyLevelUp();
    }

    public void Hide()
    {
        self.gameObject.SetActive(true);
    }
}
