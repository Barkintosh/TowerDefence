using UnityEngine;
using UnityEngine.EventSystems;

public class ImproveManager : MonoBehaviour
{
    public RangeDrawerBehaviour rangeDrawer;
    TowerBehavior selectedTower;

    void Update()
    {
        if(GameManager.instance.inputManager.leftMouseDown)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(GameManager.instance.inputManager.mousePosition);
            if (Physics.Raycast(ray, out hit) && !GameManager.instance.inputManager.overElement)
            {
                Vector2Int gridPos = GameManager.instance.gridManager.PositionInGrid(hit.point);
                if(GameManager.instance.gridManager.InGrid(gridPos) && GameManager.instance.gridManager.grid[gridPos.x, gridPos.y] != null)
                {
                    TowerBehavior towerBehavior = GameManager.instance.gridManager.grid[gridPos.x, gridPos.y].GetComponent<TowerBehavior>();
                    if(towerBehavior != null)
                    {
                        SelectTower(towerBehavior);
                    }
                    else
                    {
                        Unselect();
                    }
                }
                else
                {
                    Unselect();
                }
            }
        }
/*
        if(selectedTower != null)
        {
           
            GameManager.instance.canvasLineRenderer.DrawCanvasLine
            (
                Camera.main.WorldToScreenPoint(selectedTower.transform.position),
                GameManager.instance.interfaceManager.towerBoxBehavior.generalBox.position,
                2f,
                Color.black
            );
        }
*/
}
   
    void SelectTower(TowerBehavior _selectedTower)
    {
        selectedTower = _selectedTower;

        rangeDrawer.Draw(selectedTower.transform.position, selectedTower.param.range, 50);
        GameManager.instance.interfaceManager.towerInterface.ShowTowerInformation
        (
            selectedTower, 
            new Vector2(Screen.width/10, Screen.height/2)
        );
    }

    void Unselect()
    {
        selectedTower = null;
        GameManager.instance.interfaceManager.towerInterface.Hide();
    }
}