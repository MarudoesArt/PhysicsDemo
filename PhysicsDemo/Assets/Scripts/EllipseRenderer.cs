using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class EllipseRenderer : MonoBehaviour
{
    public LineRenderer lr;
    public Ellipse ellipse;

    [Range(3, 36)]
    public int segments;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }

    void CalculateEllipse()
    {
        Vector3[] points = new Vector3[segments + 1];
        for (int i = 0; i < segments; i++)
        {
            Vector2 position2D = ellipse.EvaluatePosition((float)i / (float)segments);
            points[i] = new Vector3(position2D.x, position2D.y, 0f);
        }
        points[segments] = points[0];

        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }

    private void OnValidate()
    {
        if(Application.isPlaying)
        {
            CalculateEllipse();
        }

    }
}
