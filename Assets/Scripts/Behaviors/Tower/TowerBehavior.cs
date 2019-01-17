using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehavior : MonoBehaviour
{
    [Header("Parameter")]
    public TowerParam param;
    public int level;

    [Header("Behavior")]
    public TowerVisualsBehavior visual;
    public WeaponBehavior weapon;

    public void LoadTower(TowerParam _param)
    {
        // Applying param
        param = _param;

        gameObject.name = "Tower_" + param.title;

        // Visuals
        visual = Instantiate(param.model, transform.position, Quaternion.identity, transform).GetComponent<TowerVisualsBehavior>();
        if(visual != null) visual.tower = this;

        // Shooting behavior
        if(weapon == null) weapon = GetComponent<WeaponBehavior>();
        if(weapon == null) weapon = gameObject.AddComponent<WeaponBehavior>();
        weapon.tower = this;

        weapon.Load(
            param.damage * param.levelMultiplier[level],
            param.speed * param.levelMultiplier[level],
            param.range * param.levelMultiplier[level]
        );
    }

    public void LevelUp()
    {
        if(level < param.levelMultiplier.Length - 1)
        {
            level++;
            weapon.Load(
                param.damage * param.levelMultiplier[level],
                param.speed / param.levelMultiplier[level],
                param.range * param.levelMultiplier[level]
            );
            GameManager.instance.interfaceManager.towerInterface.UpdateInterface();
            Debug.Log(param.name + " improved to level " + level);
        }
        else
        {
            Debug.Log("You're trying to level up " + param.name + ", but it has already reached max level");
        }
    }

    public void BuyLevelUp()
    {
        if(level < param.levelMultiplier.Length - 1 && GameManager.instance.moneyManager.Buy(param.price * param.levelMultiplier[level]))
            LevelUp();
    }

    public void LoadWeapon()
    {
        weapon.damage = param.damage * param.levelMultiplier[level];
        weapon.speed = param.speed / param.levelMultiplier[level];
        weapon.range = param.range * param.levelMultiplier[level];
    }
}
