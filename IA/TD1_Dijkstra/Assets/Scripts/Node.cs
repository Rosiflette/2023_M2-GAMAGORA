using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node 
{
    private string s_name;
    private Dictionary<Node, int> dc_neighbors;

    public Node(string name)
    {
        s_name = name;
        dc_neighbors = new Dictionary<Node, int>();
    }

    public Dictionary<Node, int> getNeighbors(){
        return dc_neighbors;
    }

    public void AddNeighbor(Node n, int distance){
        dc_neighbors.Add(n, distance);
    }

    public string getName(){
        return s_name;
    }

}
