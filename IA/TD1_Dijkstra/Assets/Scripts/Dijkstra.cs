using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Dijkstra
{
    private Dictionary<Node, int> dc_distance;
    private Dictionary<Node, Node> dc_prev;
    private List<Node> l_notVisited;
    private List<Node> l_path = new List<Node>();

    public Dijkstra(Graph g, Node source)
    {
        dc_distance = new Dictionary<Node, int>();
        dc_prev = new Dictionary<Node, Node>();
        l_notVisited = new List<Node>();

        foreach (Node n in g.getNodes())
        {
            dc_distance.Add(n, int.MaxValue);
            dc_prev.Add(n, null);
            l_notVisited.Add(n);

        }

        dc_distance[source] = 0;

        while (!(l_notVisited.Count < 1))
        {
            Node currentNode = getMinNode();
            l_notVisited.Remove(currentNode);

            foreach (KeyValuePair<Node, int> neighbor in currentNode.getNeighbors())
            {
                int sumEdge = dc_distance[currentNode] + neighbor.Value;
                if (sumEdge < dc_distance[neighbor.Key])
                {
                    dc_distance[neighbor.Key] = sumEdge;
                    dc_prev[neighbor.Key] = currentNode;
                }
            }
        }

    }

    private Node getMinNode()
    {
        Node minNode = l_notVisited[0];
        foreach (Node n in l_notVisited)
        {
            if (dc_distance[n] < dc_distance[minNode])
            {
                minNode = n;
            }
        }
        return minNode;
    }


    public void calculPath(Node destination)
    {
        if(destination == null){
            return;
        }

        l_path.Add(destination);

        if (dc_distance[destination] == 0)
        {
            l_path.Reverse();
            return;
        }
        calculPath(dc_prev[destination]);
    }

    public List<Node> getPath()
    {
        return l_path;
    }

    public void ClearPath()
    {
        l_path.Clear();
    }


}
