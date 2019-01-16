using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructionManager : MonoBehaviour
{
    public RangeDrawerBehaviour rangeDrawer;
    public TowerHologramBehavior towerHologramBehavior;
    public GameObject towerPrefab;
    public TowerParam[] towers;

    [HideInInspector] public int selectedTowerIndex = -1;   

    void Update()
    {
        if(selectedTowerIndex > -1 && GameManager.instance.inputManager.leftMouseDown)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(GameManager.instance.inputManager.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(!GameManager.instance.inputManager.overElement && GameManager.instance.gridManager.IsInside(hit.point))
                {
                    Vector2Int gridPos = GameManager.instance.gridManager.PositionInGrid(hit.point);

                    if(GameManager.instance.gridManager.grid[gridPos.x, gridPos.y] == null)
                    {
                        if(GameManager.instance.moneyManager.Buy(towers[selectedTowerIndex].price))
                            BuildDefence(gridPos);
                        else
                        {
                            Unselect();
                        }
                    }
                    else
                    {
                        Debug.Log("Object already here!");
                    }
                }
            }
        }
    }

    public void Select(int index)
    {
        if(GameManager.instance.moneyManager.EnoughMoney(towers[index].price))
        {
            selectedTowerIndex = index;
            towerHologramBehavior.Show(towers[selectedTowerIndex].model);        
        }
    }

    public void Unselect()
    {
        selectedTowerIndex = -1;
        towerHologramBehavior.Hide();
    }

    void BuildDefence(Vector2Int gridPos)
    {
        if(selectedTowerIndex > -1 && selectedTowerIndex < towers.Length)
        {
            Vector3 worldPos = GameManager.instance.gridManager.PositionInWorld(gridPos);
            GameObject newObject = Instantiate(towerPrefab, worldPos, Quaternion.identity);
            newObject.GetComponent<TowerBehavior>().LoadTower(towers[selectedTowerIndex]);
            GameManager.instance.gridManager.grid[gridPos.x, gridPos.y] = newObject;
            Unselect();
        }
    }
}