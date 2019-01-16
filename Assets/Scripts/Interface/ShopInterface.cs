using UnityEngine;
using UnityEngine.UI;

public class ShopInterface : MonoBehaviour
{
    public Text moneyText;

    public void UpdateInterface()
    {
        moneyText.text = GameManager.instance.moneyManager.money.ToString();
    }
}
