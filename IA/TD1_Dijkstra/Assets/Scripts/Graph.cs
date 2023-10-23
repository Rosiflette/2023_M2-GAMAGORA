using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{

    private List<Node> l_nodeList;

    public Graph()
    {
        l_nodeList = new List<Node>();
    }

    public List<Node> getNodes(){
        return l_nodeList;
    }

    public void Add(Node n){
        l_nodeList.Add(n);
    }
}
