using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Graph
{

    private Dictionary<Vector3Int, Node> l_nodeList;

    public Graph()
    {
        l_nodeList = new Dictionary<Vector3Int, Node>();
    }

    public List<Node> getNodes()
    {
        return l_nodeList.Values.ToList();
    }
    public List<Vector3Int> getTilesPosition()
    {
        return l_nodeList.Keys.ToList();
    }

    public void Add(Vector3Int v, Node n)
    {
        l_nodeList.Add(v, n);
    }

    public Dictionary<Vector3Int, Node> getDico()
    {
        return l_nodeList;
    }

    public Node getNodeByPosition(Vector3Int pos)
    {
        try
        {
            Node n = l_nodeList[pos];
            return n;
        }
        catch (KeyNotFoundException)
        {
            return null;
        }

        
    }
}
