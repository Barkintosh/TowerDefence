using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemButtonBehavior : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Referencies")]
    public Image background;
    public Image icon;
    public Text nameText;
    public Text priceText; 
    [Space(5)]
    public int index;

    RectTransform self;


    void Start()
    {
        self = GetComponent<RectTransform>();
        ConstructionManager cm = GameManager.instance.constructionManager;
        if(index >= 0 && index < cm.towers.Length)
        {
            icon.sprite = cm.towers[index].image;
            nameText.text = cm.towers[index].title;
            priceText.text = cm.towers[index].price.ToString();

            gameObject.name = "Buy_" + cm.towers[index].title;
        }
        else
        {
            Debug.Log("undefined tower");
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Vector2 newPos = new Vector2(self.position.x - 200f, self.position.y);
        GameManager.instance.interfaceManager.towerBoxBehavior.ShowTowerInformation
        (
            GameManager.instance.constructionManager.towers[index],
            newPos
        );
    }
 
    public void OnPointerExit(PointerEventData eventData)
    {
        GameManager.instance.interfaceManager.towerBoxBehavior.Hide();
    }

    public void SelectTower(int which)
    {
        GameManager.instance.constructionManager.Select(which);
    }
}
