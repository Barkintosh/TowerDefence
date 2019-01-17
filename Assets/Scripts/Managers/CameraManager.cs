using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    [Header("Transforms")] [Space(1)]
    public Transform camTransform;
    public Transform camCenter;
    public Transform camPivot;
    Vector3 startPosition;

    [Space(2)] [Header("=== SETTINGS ===")] [Space(1)]
    [Header("Drift")]
    public float driftSensibility = 1f;
    [Header("Rotating")]
    public float rotateSensibility = 1f;
    public float minLookAngle = 10f;
    public float maxLookAngle = 80f;
    [Header("Zoom")]
    public float zoomStep = 1f;
    public float minZoom = 0f;
    public float maxZoom = 10f;

    Vector3 mouseDelta;
    Vector3 lastMousePosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        camTransform.LookAt(camCenter); 
        if (GameManager.instance.inputManager.middleMouse) Move();
        if (GameManager.instance.inputManager.rightMouse) Rotation();
        if(Input.GetKeyDown(KeyCode.V)) camCenter.position = startPosition;
        Zoom();
    }

    private void Move()
    {
        if (GameManager.instance.inputManager.middleMouseDown)
            lastMousePosition = (Vector3)Input.mousePosition;
        
        mouseDelta = (Vector3)lastMousePosition - (Vector3)Input.mousePosition;
        camCenter.position += (mouseDelta.x * camTransform.right.normalized) * driftSensibility;
        camCenter.position += (mouseDelta.y * new Vector3(camTransform.forward.x, 0, camTransform.forward.z).normalized) * driftSensibility;
        lastMousePosition = (Vector3)Input.mousePosition;
    }

    private void Rotation()
    {
        Vector2 lookDirection = new Vector2(
            Input.GetAxis("Mouse X") * rotateSensibility,
            Input.GetAxis("Mouse Y") * rotateSensibility
        );
        
        camPivot.rotation = Quaternion.Euler(camPivot.eulerAngles.x, camPivot.eulerAngles.y + lookDirection.x, camPivot.eulerAngles.z + lookDirection.y);
    } 

    private void Zoom() 
    {
        if(!GameManager.instance.inputManager.overElement)
        {
            if(Input.GetAxis("Mouse ScrollWheel") > 0 && camTransform.position.y > minZoom)
                camTransform.localPosition += new Vector3(zoomStep, 0f, 0f);
            else if(Input.GetAxis("Mouse ScrollWheel") < 0 && camTransform.position.y < maxZoom)
                camTransform.localPosition -= new Vector3(zoomStep, 0f, 0f);
        }
    }
}
