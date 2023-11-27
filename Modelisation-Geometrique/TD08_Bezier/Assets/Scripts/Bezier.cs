using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlgoBezier : MonoBehaviour
{
    [SerializeField] private int nbBezier;
    [SerializeField] private Transform controlPoint0;
    [SerializeField] private Transform controlPoint1;
    [SerializeField] private Transform controlPoint2;
    [SerializeField] private Transform controlPoint3;

    private void OnDrawGizmos()
    {
        if (nbBezier < 1)
            nbBezier = 1;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(controlPoint0.position, controlPoint1.position);
        Gizmos.DrawLine(controlPoint1.position, controlPoint2.position);
        Gizmos.DrawLine(controlPoint2.position, controlPoint3.position);

        List<Vector3> points = new List<Vector3>();

        for (float t = 0; t <= 1; t += 1f / nbBezier)
        {
            Vector3 position = BezierInterpolation(t, controlPoint0.position, controlPoint1.position, controlPoint2.position, controlPoint3.position);
            points.Add(position);
        }

        Gizmos.color = Color.green;
        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i], points[i + 1]);
        }
    }

    Vector3 BezierInterpolation(float t, Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3)
    {
        float u = 1 - t;
        float u2 = u * u;
        float u3 = u2 * u;
        float t2 = t * t;
        float t3 = t2 * t;

        float blend1 = u3;
        float blend2 = 3 * u2 * t;
        float blend3 = 3 * u * t2;
        float blend4 = t3;

        Vector3 position = blend1 * p0 + blend2 * p1 + blend3 * p2 + blend4 * p3;

        return position;
    }

}
