using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputManager : MonoBehaviour
{
    [Header("INPUTS")]
    public bool leftMouseDown;
    public bool leftMouse;
    public bool leftMouseUp;

    public bool middleMouseDown;
    public bool middleMouse;
    public bool middleMouseUp;

    public bool rightMouseDown;
    public bool rightMouse;
    public bool rightMouseUp;
    [Header("POSITIONS")]
    public Vector2 mousePosition;
    [Header("OTHERS")]
    public bool overElement;

    void Update()
    {
        GetInputs();
    }

    void GetInputs()
    {
        leftMouseDown = Input.GetKeyDown(KeyCode.Mouse0);
        leftMouse = Input.GetKey(KeyCode.Mouse0);
        leftMouseUp = Input.GetKeyUp(KeyCode.Mouse0);
        
        rightMouseDown = Input.GetKeyDown(KeyCode.Mouse1);
        rightMouse = Input.GetKey(KeyCode.Mouse1);
        rightMouseUp = Input.GetKeyUp(KeyCode.Mouse1);

        middleMouseDown = Input.GetKeyDown(KeyCode.Mouse2);
        middleMouse = Input.GetKey(KeyCode.Mouse2);
        middleMouseUp = Input.GetKeyUp(KeyCode.Mouse2);

        mousePosition = Input.mousePosition;

        overElement = EventSystem.current.IsPointerOverGameObject();
    }
}
