using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Ellipse
{
    [Range(0, 10)]
    public float xAxis;

    [Range(0, 10)]
    public float yAxis;

    public Ellipse(float xAxis, float yAxis)
    {
        this.xAxis = xAxis;
        this.yAxis = yAxis;
    }

    public Vector2 EvaluatePosition(float t)
    {
        float angle = Mathf.Deg2Rad * 360 * t;
        float x = Mathf.Sin(angle) * xAxis;
        float y = Mathf.Cos(angle) * yAxis;
        return new Vector2(x, y);
    }
}
