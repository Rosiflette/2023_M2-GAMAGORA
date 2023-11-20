using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaikinAlgo : MonoBehaviour
{

    [SerializeField] private int nbChaikin;


    private void OnDrawGizmos()
    {
        List<Vector3> points = new List<Vector3>();
        foreach (Transform child in gameObject.transform)
        {
            points.Add(child.position);
        }

        Gizmos.color = Color.blue;
        for (int i = 0; i < points.Count-1; i++)
        {
            Gizmos.DrawLine(points[i], points[i + 1]);
        }
        Gizmos.DrawLine(points[0], points[points.Count-1]);

        for(int i = 0; i < nbChaikin; i++)
        {
            points = Chaikin(points);

        }
        Gizmos.color = Color.green;
        for (int i = 0; i < points.Count - 1; i++)
        {
            Gizmos.DrawLine(points[i], points[i + 1]);
        }
        Gizmos.DrawLine(points[0], points[points.Count - 1]);

    }

    List<Vector3> Chaikin(List<Vector3> nodes)
    {
        List<Vector3> new_nodes = new List<Vector3>();

        for (int i = 0; i < nodes.Count - 1; ++i)
        {
            new_nodes.Add(3f / 4f * nodes[i] + 1f / 4f * nodes[i + 1]);
            new_nodes.Add(1f / 4f * nodes[i] + 3f / 4f * nodes[i + 1]);
        }
        new_nodes.Add(3f / 4f * nodes[nodes.Count - 1] + 1f / 4f * nodes[0]);
        new_nodes.Add(1f / 4f * nodes[nodes.Count - 1] + 3f / 4f * nodes[0]);

        return new_nodes;
    }

}
