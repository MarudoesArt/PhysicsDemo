using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMotion : MonoBehaviour
{
    public Transform orbitingObject;
    public Ellipse orbitPath;

    [Range(0f, 1f)]
    public float orbitProgress = 0f;

    [Range(0f, 10f)]
    public float orbitPeriod = 3f; //How long in seconds it takes to go around the orbit

    public bool orbitActive = true;

    // Start is called before the first frame update
    void Start()
    {
        if(orbitingObject == null)
        {
            orbitActive = false;
            return;
        }
        SetOrbitingObjectPos();
        if(orbitActive == true)
        StartCoroutine(AnimateOrbit());
    }

    void SetOrbitingObjectPos()
    {
        Vector2 orbitPos = orbitPath.EvaluatePosition(orbitProgress);
        orbitingObject.localPosition = new Vector3(orbitPos.x, 0f, orbitPos.y);
    }

    IEnumerator AnimateOrbit()
    {
        if(orbitPeriod < 0.1f)
        {
            orbitPeriod = 0.1f;
        }
        float orbitSpeed = 1f / orbitPeriod;
        while(orbitActive == true)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            SetOrbitingObjectPos();
            yield return null;
        }
    }

}
