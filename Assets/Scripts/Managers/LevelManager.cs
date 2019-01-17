using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<Vector3> path = new List<Vector3>();
    public LineRenderer lineRenderer;

    void Start()
    {
        if(lineRenderer == null) lineRenderer = GetComponent<LineRenderer>();
        GeneratePath();
        DrawPath();

        for( int i = 0; i < GameManager.instance.enemyManager.enemies.Length; i++)
        {
            GameManager.instance.enemyManager.SpawnEnemy(i, path[0]);
        }
    }

    void GeneratePath()
    {
        for( int i = 0; i < GameManager.instance.gridManager.gridSize; i++)
        {
            Vector3 newPoint = new Vector3(i, 0f ,GameManager.instance.gridManager.gridSize/2);
            GameManager.instance.gridManager.grid[i, GameManager.instance.gridManager.gridSize/2] = gameObject;
            path.Add(newPoint);
        }
    }

    void DrawPath()
    {
        lineRenderer.positionCount = path.Count;

        for( int i = 0; i < path.Count; i++)
        {
            lineRenderer.SetPosition(i, path[i]);
        }
    }
}
