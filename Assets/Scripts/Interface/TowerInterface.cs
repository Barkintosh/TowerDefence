using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class TowerInterface : MonoBehaviour
{
    [Header("Referencies")]
    public RectTransform self;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    [Header("Prefabs")]
    public GameObject weaponInterfacePrefab;
    WeaponInterface weaponInterface;

    TowerBehavior lastTower;
    Vector2 lastPosition;

    public void ShowTowerInformation(TowerBehavior tower, Vector2? pos = null)
    {
        if(pos != null)
            self.position = (Vector3)pos;
        else
            self.position = new Vector2(Screen.width/2, Screen.height/2);

        titleText.text = tower.param.title;
        //requiredHeight += titleText.GetComponent<RectTransform>().sizeDelta.y;
        descriptionText.text = tower.param.description;
        //descriptionBox.sizeDelta = new Vector2(descriptionBox.sizeDelta.x, descriptionText.text.Length * 0.5f);
        //requiredHeight += descriptionBox.sizeDelta.y + 10;
        //self.sizeDelta = new Vector2(self.sizeDelta.x, requiredHeight);
        //ShowTowerStats(tower.weapon);

        if(weaponInterface == null)
        {
            weaponInterface = Instantiate(weaponInterfacePrefab, transform.position, Quaternion.identity, transform)
            .GetComponent<WeaponInterface>();
        }

        weaponInterface.ShowWeapon(tower.weapon);
        weaponInterface.self.position = new Vector2
        (
            self.position.x + self.sizeDelta.x*0.5f + weaponInterface.self.sizeDelta.x*0.5f + GameManager.instance.interfaceManager.boxesSpacing, 
            self.position.y
        );

        lastTower = tower;
        lastPosition = (Vector2)self.position;

        self.gameObject.SetActive(true);
    }

    public void Hide()
    {
        self.gameObject.SetActive(false);
        if(weaponInterface != null) weaponInterface.Hide();
    }

    public void UpdateInterface()
    {
        if(lastTower != null)
            ShowTowerInformation(lastTower, lastPosition);
    }
}
