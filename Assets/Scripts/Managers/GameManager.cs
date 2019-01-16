using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("MANAGERS")]
    public Library library;
    public MoneyManager moneyManager;
    public SystemManager systemManager;
    public InputManager inputManager;
    public GridManager gridManager;
    public CameraManager cameraManager;
    public ConstructionManager constructionManager;
    public LevelManager levelManager;
    public EnemyManager enemyManager;
    [Header("INTERFACE")]
    public HealthBarManager healthBarManager;
    public CanvasLineRenderer canvasLineRenderer;
    public InterfaceManager interfaceManager;

    void Awake()
    {
        instance = this;

        if(library == null) library = GetComponentInChildren<Library>();
        if(moneyManager == null) moneyManager = GetComponentInChildren<MoneyManager>();
        if(systemManager == null) systemManager = GetComponentInChildren<SystemManager>();
        if(inputManager == null) inputManager = GetComponentInChildren<InputManager>();
        if(gridManager == null) gridManager = GetComponentInChildren<GridManager>();
        if(cameraManager == null) cameraManager = GetComponentInChildren<CameraManager>();
        if(constructionManager == null) constructionManager = GetComponentInChildren<ConstructionManager>();
        if(levelManager == null) levelManager = GetComponentInChildren<LevelManager>();
        if(enemyManager == null) enemyManager = GetComponentInChildren<EnemyManager>();
    }
}
