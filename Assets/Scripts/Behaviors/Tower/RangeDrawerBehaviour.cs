using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDrawerBehaviour : MonoBehaviour
{
    LineRenderer lineRenderer;

    void Start()
    {
        if(lineRenderer == null) lineRenderer = GetComponent<LineRenderer>();
        if(lineRenderer == null) lineRenderer = gameObject.AddComponent<LineRenderer>();
        Hide();
    }

    public void Draw(Vector3 _position, float radius, int segment = 20)
    {
        lineRenderer.enabled = true;

        float angle = 0f;
        lineRenderer.positionCount = segment;

        for( int i = 0; i < segment; i++)
        {
            Vector3 newVertices = new Vector3(_position.x + radius * Mathf.Sin(Mathf.Deg2Rad * angle), _position.y + 0.5f, _position.z + radius * Mathf.Cos(Mathf.Deg2Rad * angle));
            lineRenderer.SetPosition(i, newVertices);

            angle += 360f / segment;
        }
    }

    public void Hide()
    {
        lineRenderer.enabled = false;
    }
}
