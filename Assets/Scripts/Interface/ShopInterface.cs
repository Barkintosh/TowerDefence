using UnityEngine;
using UnityEngine.UI;

public class ShopInterface : MonoBehaviour
{
    public Text moneyText;
    public GameObject itemButtonPrefab;
    public RectTransform shopContentHolder;

    void Start()
    {
        float requiredHeight = 0f;
        for( int i = 0; i < GameManager.instance.constructionManager.towers.Length; i++)
        {
            ItemButtonBehavior newItemButton = Instantiate(itemButtonPrefab, shopContentHolder.position, Quaternion.identity, shopContentHolder).GetComponent<ItemButtonBehavior>();
            newItemButton.index = i;
            requiredHeight += newItemButton.self.sizeDelta.y + 10;
        }
        shopContentHolder.sizeDelta = new Vector2(shopContentHolder.sizeDelta.x, requiredHeight);
    }


    public void UpdateInterface()
    {
        moneyText.text = GameManager.instance.moneyManager.money.ToString();
    }
}
