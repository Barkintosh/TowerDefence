using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;

public class TowerBoxBehavior : MonoBehaviour
{
    [Header("Referencies")]
    public GameObject valuePrefab;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI descriptionText;

    public RectTransform generalBox;
    public RectTransform descriptionBox;

    public void ShowTowerInformation(TowerBehavior tower, Vector2? pos = null)
    {
        generalBox.gameObject.SetActive(true);

        if(pos != null)
            generalBox.position = (Vector3)pos;
        else
            generalBox.position = new Vector2(Screen.width/2, Screen.height/2);

        titleText.text = tower.param.title;
        //requiredHeight += titleText.GetComponent<RectTransform>().sizeDelta.y;
        descriptionText.text = tower.param.description;
        //descriptionBox.sizeDelta = new Vector2(descriptionBox.sizeDelta.x, descriptionText.text.Length * 0.5f);
        //requiredHeight += descriptionBox.sizeDelta.y + 10;
        //generalBox.sizeDelta = new Vector2(generalBox.sizeDelta.x, requiredHeight);

        //ShowTowerStats(tower.weapon);
    }

    public void Hide()
    {
        generalBox.gameObject.SetActive(false);
    }
}
