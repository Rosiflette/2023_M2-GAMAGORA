using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Node 
{
    private TileData t_tile;
    private Vector3Int v_position;
    private Dictionary<Node, float> dc_neighbors;
    public Node(Vector3Int pos, TileData tile)
    {
        v_position = pos;
        t_tile = tile;
        dc_neighbors = new Dictionary<Node, float>();
    }

    public void AddNeighbor(Node n, float distance){
        dc_neighbors.Add(n, distance);
    }

    public Dictionary<Node, float> getNeighbors(){
        return dc_neighbors;
    }
    public TileData getTile(){
        return t_tile;
    }

    public Vector3Int getPosition(){
        return v_position;
    }

    public float getSpeed(){
        return t_tile.walkingspeed;
    }
}
