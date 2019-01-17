using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHologramBehavior : MonoBehaviour
{
    public List<Renderer> renderers = new List<Renderer>();
    public GameObject hologram;
    public RangeDrawerBehaviour rangeDrawer;

    void Start()
    {
        if(rangeDrawer == null) rangeDrawer = GetComponentInChildren<RangeDrawerBehaviour>();
        if(rangeDrawer == null) rangeDrawer = gameObject.AddComponent<RangeDrawerBehaviour>();
    }

    void Update()
    { 
        if(hologram != null)
        {            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(GameManager.instance.inputManager.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if(!GameManager.instance.inputManager.overElement && GameManager.instance.gridManager.IsInside(hit.point))
                {
                    hologram.transform.position = GameManager.instance.gridManager.PositionInWorld(
                        GameManager.instance.gridManager.PositionInGrid(hit.point)
                    );
                    
                    if(GameManager.instance.constructionManager.selectedTowerIndex > -1)
                        rangeDrawer.Draw(
                            hologram.transform.position, 
                            GameManager.instance.constructionManager.towers[GameManager.instance.constructionManager.selectedTowerIndex].range
                        );
                }
            }
        }
    }

    public void Show(GameObject o)
    {
        Hide();
        renderers.Clear();

        hologram = Instantiate(o, transform.position, Quaternion.identity, transform);
        GetMeshRenderers(hologram.transform);

        foreach(Renderer r in renderers)
        {
            r.material = GameManager.instance.library.holoMaterial;
        }
    }

    public void Hide()
    {
        Destroy(hologram);
        rangeDrawer.Hide();
    }

    void GetMeshRenderers(Transform t)
    {
        for( int i = 0; i < t.childCount; i++ )
        {
            GetMeshRenderers(t.GetChild(i));
        }

        Renderer r = t.GetComponent<Renderer>();
        if(r != null)  renderers.Add(r);
    }
}
