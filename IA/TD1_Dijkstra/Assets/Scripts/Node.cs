using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Node 
{
    // private string s_name;

    private TileData t_tile;

    private Vector3Int v_position;

    private Dictionary<Node, int> dc_neighbors;

    public Node(Vector3Int pos, TileData tile)
    {
        // s_name = name;
        v_position = pos;
        t_tile = tile;
        dc_neighbors = new Dictionary<Node, int>();
    }


    public void AddNeighbor(Node n, int distance){
        dc_neighbors.Add(n, distance);
    }

    // public string getName(){
    //     return s_name;
    // }

    public Dictionary<Node, int> getNeighbors(){
        return dc_neighbors;
    }
    public TileData getTile(){
        return t_tile;
    }

    public Vector3Int getPosition(){
        return v_position;
    }
}
