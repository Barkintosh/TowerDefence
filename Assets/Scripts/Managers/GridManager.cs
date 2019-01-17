using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [Header("Settings")]
    public int gridSize = 10;
    public float cellSize = 1f;
    public GameObject[,] grid;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        grid = new GameObject[gridSize, gridSize];
        
        for( int i = 0; i < grid.GetLength(0); i++)
        {
            for( int j = 0; j < grid.GetLength(1); j++)
            {
                //Instantiate(cell, new Vector3(i, 0.01f, j), Quaternion.identity, transform);
            }
        }

        //GameManager.instance.cameraManager.MoveCamera(new Vector3(gridSize, 10f, 0f), 1f);
    }

    public bool IsInside(Vector3 _position)
    {
        if(
        _position.x < 0 
        || _position.z < 0
        || _position.x > gridSize - 1
        || _position.z > gridSize - 1
        )
        {return false;}
        else return true;
    }

    public bool InGrid(Vector2Int _position)
    {
        if(
        _position.x < 0 
        || _position.y < 0
        || _position.x > gridSize - 1
        || _position.y > gridSize - 1
        )
        {return false;}
        else return true;
    }

    public Vector2Int PositionInGrid(Vector3 _position)
    {
        Vector3 coord = new Vector3(_position.x/cellSize + cellSize/2, _position.y, _position.z/cellSize + cellSize/2);
        return new Vector2Int(Mathf.FloorToInt(coord.x), Mathf.FloorToInt(coord.z));
    }

    public Vector3 PositionInWorld(Vector2Int _position)
    {
        Vector3 coord = new Vector2(_position.x/cellSize, _position.y/cellSize);
        return new Vector3(Mathf.FloorToInt(coord.x)/* + cellSize/2*/, 0, Mathf.FloorToInt(coord.y)/* + cellSize/2*/);
    }
}
