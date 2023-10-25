using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSphere
{
    Vector3 center;
    int rayon;

    public CreateSphere(Vector3 center, int rayon)
    {
        this.center = center;
        this.rayon = rayon;
    }


    public List<Vector3> getBox()
    {
        return new List<Vector3> { center - Vector3.one * rayon, center + Vector3.one * rayon };
    }

    
    public bool IsInside(Vector3 pos)
    {
        return (Vector3.Dot(pos-center, pos-center) - rayon * rayon) > 0;
    }



}
