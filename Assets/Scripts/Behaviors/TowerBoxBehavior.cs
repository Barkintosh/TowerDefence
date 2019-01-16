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
    public RectTransform valueBox;

    //public TowerParam test;
    [Header("Referencies")]
    public float shiftValue = 5f;

    int valueCount = 0;
    float requiredHeight = 0f;

    List<ValueDisplay> valueDisplays = new List<ValueDisplay>();

/*
    public void Start()
    {
        ShowTowerInformation(test);
    }
*/
    public void ShowTowerInformation(TowerParam param, Vector2? pos = null)
    {
        Reset();
        generalBox.gameObject.SetActive(true);

        if(pos != null)
            generalBox.position = (Vector3)pos;
        else
            generalBox.position = new Vector2(Screen.width/2, Screen.height/2);

        titleText.text = param.title;
        requiredHeight += titleText.GetComponent<RectTransform>().sizeDelta.y;
        descriptionText.text = param.description;
        descriptionBox.sizeDelta = new Vector2(descriptionBox.sizeDelta.x, descriptionText.text.Length * 0.5f);
        requiredHeight += descriptionBox.sizeDelta.y + 10;

        generalBox.sizeDelta = new Vector2(generalBox.sizeDelta.x, requiredHeight);

        ShowTowerStats(param);
    }

    public void ShowTowerStats(TowerParam param)
    {
        requiredHeight = 0f;

        if(param.damage > 0) NewValueDisplay(param.damage.ToString(), GameManager.instance.library.damageIcon);
        if(param.speed > 0) NewValueDisplay(param.speed.ToString(), GameManager.instance.library.speedIcon);
        if(param.range > 0) NewValueDisplay(param.range.ToString(), GameManager.instance.library.rangeIcon);

        valueBox.sizeDelta = new Vector2(valueBox.sizeDelta.x, requiredHeight + shiftValue);
    }


    public void NewValueDisplay(string value, Sprite image)
    {
        valueDisplays.Add(Instantiate(valuePrefab, valueBox.position, Quaternion.identity, valueBox).GetComponent<ValueDisplay>());
        ValueDisplay vd = valueDisplays[valueDisplays.Count - 1];
        
        vd.self.anchorMin = new Vector2(0.5f, 1f);
        vd.self.anchorMax = new Vector2(0.5f, 1f);
        vd.self.pivot = new Vector2(0.5f, 1f);
        
        vd.self.localPosition = new Vector2(0f, -(shiftValue + vd.self.sizeDelta.y) * valueCount - shiftValue);
        vd.valueImage.sprite = image;
        vd.valueText.text = value.ToString();

        requiredHeight += shiftValue + vd.self.sizeDelta.y;
        valueCount++;
    }

    public void Reset()
    {
        valueCount = 0;
        requiredHeight = 0f;

        foreach(ValueDisplay vd in valueDisplays)
        {
            Destroy(vd.gameObject);
        }
        valueDisplays.Clear();
    }

    public void Hide()
    {
        generalBox.gameObject.SetActive(false);
    }
}
