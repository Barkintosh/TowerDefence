using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundDrawerBehaviour : MonoBehaviour
{
    public LineRenderer lineRenderer;

    void Start()
    {
        if(lineRenderer == null) lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.positionCount = 4;

        lineRenderer.SetPosition(0, 
            new Vector3(
                -0.5f, 0.1f, -0.5f
            )
        );

        lineRenderer.SetPosition(1, 
            new Vector3(
                GameManager.instance.gridManager.gridSize - 0.5f, 0.5f, -0.5f
            )
        );

        lineRenderer.SetPosition(2, 
            new Vector3(
                GameManager.instance.gridManager.gridSize - 0.5f, 0.5f, GameManager.instance.gridManager.gridSize - 0.5f
            )
        );

        lineRenderer.SetPosition(3, 
            new Vector3(
                -0.5f, 0.5f, GameManager.instance.gridManager.gridSize - 0.5f
            )
        );
    }
}
