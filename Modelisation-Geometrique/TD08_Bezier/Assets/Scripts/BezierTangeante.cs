using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AlgoBezierTangeante : MonoBehaviour
{
   [SerializeField] private int nbBezier;
    [SerializeField] private List<Transform> list1;
    [SerializeField] private List<Transform> list2;

    private void OnDrawGizmos()
    {
        if (nbBezier < 1)
            nbBezier = 1;

        Gizmos.color = Color.red;
        DrawCurve(list1);

        Gizmos.color = Color.blue;
        DrawCurve(list2);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(list1[list1.Count - 1].position, list2[0].position);
    }

    void DrawCurve(List<Transform> controlPoints)
    {
        for (int i = 0; i < controlPoints.Count - 1; i++)
        {
            Gizmos.DrawLine(controlPoints[i].position, controlPoints[i + 1].position);
        }

        List<Vector3> points = new List<Vector3>();

        for (float t = 0; t <= 1; t += 1f / nbBezier)
        {
            Vector3 position = BezierInterpolation(t, controlPoints);
            points.Add(position);
        }

        Gizmos.color = Color.green;
        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i], points[i + 1]);
        }
    }

    Vector3 BezierInterpolation(float t, List<Transform> controlPoints)
    {
        int n = controlPoints.Count - 1;

        if (n < 0)
            return Vector3.zero;

        Vector3[] blendedPoints = new Vector3[n + 1];
        for (int i = 0; i <= n; i++)
        {
            blendedPoints[i] = controlPoints[i].position;
        }

        for (int r = 1; r <= n; r++)
        {
            for (int i = 0; i <= n - r; i++)
            {
                blendedPoints[i] = (1 - t) * blendedPoints[i] + t * blendedPoints[i + 1];
            }
        }

        return blendedPoints[0];
    }
}