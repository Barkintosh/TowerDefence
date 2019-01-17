using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponInterface : MonoBehaviour
{
    [Header("Referencies")]
    public RectTransform self;
    public GameObject valuePrefab;
    public GameObject improvePrefab;
    [Header("Settings")]
    public float shiftValue = 5f;

    int valueCount = 0;
    float requiredHeight = 0f;
    List<ValueDisplay> values = new List<ValueDisplay>();
    ImproveInterface improveInterface;

    public void ShowWeapon(WeaponBehavior weapon)
    {
        Reset();

        if(weapon.damage > 0) NewValueDisplay(weapon.damage.ToString("F1"), GameManager.instance.library.damageIcon);
        if(weapon.speed > 0) NewValueDisplay(weapon.speed.ToString("F1"), GameManager.instance.library.speedIcon);
        if(weapon.range > 0) NewValueDisplay(weapon.range.ToString("F1"), GameManager.instance.library.rangeIcon);

        self.sizeDelta = new Vector2(self.sizeDelta.x, requiredHeight + shiftValue);

        self.gameObject.SetActive(true);

        if(improveInterface == null)
        {
            improveInterface = Instantiate(improvePrefab, transform.position, Quaternion.identity, transform)
            .GetComponent<ImproveInterface>();
        }

        improveInterface.weapon = weapon;        
        improveInterface.self.position = new Vector2
        (
            self.position.x, 
            self.position.y - self.sizeDelta.y*0.5f - improveInterface.self.sizeDelta.y*0.5f - GameManager.instance.interfaceManager.boxesSpacing
        );
        improveInterface.ChangePrice(weapon.tower.param.price * weapon.tower.param.levelMultiplier[weapon.tower.level]);
    }

    public void NewValueDisplay(string value, Sprite image)
    {
        values.Add(Instantiate(valuePrefab, self.position, Quaternion.identity, self).GetComponent<ValueDisplay>());
        ValueDisplay vd = values[values.Count - 1];
        
        /*
        vd.self.anchorMin = new Vector2(0.5f, 1f);
        vd.self.anchorMax = new Vector2(0.5f, 1f);
        vd.self.pivot = new Vector2(0.5f, 1f);
        */
        //vd.self.localPosition = new Vector2(0f, -vd.self.sizeDelta.y * valueCount);
        vd.valueImage.sprite = image;
        vd.valueText.text = value;

        requiredHeight += shiftValue + vd.self.sizeDelta.y;
        valueCount++;
    }

    public void Hide()
    {
        self.gameObject.SetActive(false);
        improveInterface.Hide();
    }

    public void Reset()
    {
        foreach(ValueDisplay vd in values)
        {
            Destroy(vd.gameObject);
        }
        valueCount = 0;
        requiredHeight = 0f;
        values.Clear();
    }
}
