using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AStar
{

    private List<Node> l_toVisit;
    private Dictionary<Node, Node> dc_prev;
    private Dictionary<Node, float> dc_distance;
    private Dictionary<Node, float> dc_distanceWithHeuristique;
    private List<Node> l_path = new List<Node>();

    private Node n_goal;




    public AStar(Graph g, Node start, Node goal)
    {
        n_goal = goal;

        l_toVisit = new List<Node>();
        dc_prev = new Dictionary<Node, Node>();
        dc_distance = new Dictionary<Node, float>();
        dc_distanceWithHeuristique = new Dictionary<Node, float>();
        if (n_goal != null)
        {
            SearchPath(g, start);

        }

    }

    private List<Node> SearchPath(Graph g, Node start)
    {
        l_toVisit.Add(start);

        foreach (Node n in g.getNodes())
        {
            dc_distance.Add(n, float.MaxValue);
            dc_distanceWithHeuristique.Add(n, float.MaxValue);
            // dc_prev.Add(n, null);
        }

        l_toVisit.Add(start);
        dc_distance[start] = 0;

        dc_distanceWithHeuristique[start] = Heuristique(start);



        while (!(l_toVisit.Count < 1))
        {
            Node currentNode = getMinNode();
            if (currentNode.getPosition() == n_goal.getPosition())
            {
                return ReconstructPath(currentNode);
            }

            l_toVisit.Remove(currentNode);

            foreach (KeyValuePair<Node, int> neighbor in currentNode.getNeighbors())
            {

                float distanceOriginNeighbor = dc_distance[currentNode] + neighbor.Value;
                if (distanceOriginNeighbor < dc_distance[neighbor.Key])
                {
                    dc_prev[neighbor.Key] = currentNode;
                    dc_distance[neighbor.Key] = distanceOriginNeighbor;
                    dc_distanceWithHeuristique[neighbor.Key] = distanceOriginNeighbor + Heuristique(neighbor.Key);
                    if (!l_toVisit.Contains(neighbor.Key))
                    {
                        l_toVisit.Add(neighbor.Key);
                    }

                }

            }

        }

        return new List<Node>();

    }

    private float Heuristique(Node from)
    {
        return Vector3.Distance(from.getPosition(), n_goal.getPosition());
    }

    private Node getMinNode()
    {
        Node minNode = l_toVisit[0];
        foreach (Node n in l_toVisit)
        {
            if (dc_distance[n] < dc_distance[minNode])
            {
                minNode = n;
            }
        }
        return minNode;
    }

    public List<Node> ReconstructPath(Node currentNode)
    {
        l_path.Add(currentNode);

        while (dc_prev.ContainsKey(currentNode))
        {
            currentNode = dc_prev[currentNode];
            l_path.Add(currentNode);
        }
        dc_prev.Reverse();
        return l_path;
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
