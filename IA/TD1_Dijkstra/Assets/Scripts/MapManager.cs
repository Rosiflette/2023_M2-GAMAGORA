using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapManager : MonoBehaviour
{

    [SerializeField] private Tilemap t_map;
    [SerializeField] private List<TileData> l_typesTile;
    private Dictionary<TileBase, TileData> dc_dataFromTiles;
    private Graph _graph = new Graph();
    private Dijkstra dij;


    void Awake()
    {
        dc_dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach (TileData typeTile in l_typesTile)
        {
            foreach (TileBase tile in typeTile.tiles)
            {
                dc_dataFromTiles.Add(tile, typeTile);
            }

        }
    }


    void Start()
    {
        BoundsInt _bounds = t_map.cellBounds;
        foreach (Vector3Int position in _bounds.allPositionsWithin)
        {
            Tile tile = t_map.GetTile<Tile>(position);
            if (tile != null)
            {
                _graph.Add(position, new Node(position, dc_dataFromTiles[tile]));
            }
        }

        foreach (Node nodeDic in _graph.getNodes())
        {

            Vector3Int v = nodeDic.getPosition();

            Vector3Int top = new Vector3Int(v.x, v.y + 1, v.z);
            Vector3Int bottom = new Vector3Int(v.x, v.y - 1, v.z);
            Vector3Int left = new Vector3Int(v.x + 1, v.y, v.z);
            Vector3Int right = new Vector3Int(v.x - 1, v.y, v.z);

            Node neighbor = _graph.getNodeByPosition(top);
            if (neighbor != null)
            {
                nodeDic.AddNeighbor(neighbor, 2);
            }
            neighbor = _graph.getNodeByPosition(bottom);
            if (neighbor != null)
            {
                nodeDic.AddNeighbor(neighbor, 2);

            }
            neighbor = _graph.getNodeByPosition(right);
            if (neighbor != null)
            {
                nodeDic.AddNeighbor(neighbor, 2);
            }
            neighbor = _graph.getNodeByPosition(left);
            if (neighbor != null)
            {
                nodeDic.AddNeighbor(neighbor, 2);

            }
        }

        dij = new Dijkstra(_graph, _graph.getNodes()[0]);
        dij.calculPath(_graph.getNodes()[0]);
        ColorizeMap(dij.getPath(), Color.gray);
    }

    private void ColorizeMap(List<Node> path, Color col)
    {
        Tile tile;
        bool startingTile = true;
        foreach (Node currentNode in path)
        {
            if (startingTile)
            {
                Vector3Int position = currentNode.getPosition();
                tile = t_map.GetTile<Tile>(position);
                t_map.SetTileFlags(position, TileFlags.None);
                t_map.SetColor(position, Color.gray);
                startingTile = false;
            }
            else
            {
                Vector3Int position = currentNode.getPosition();
                tile = t_map.GetTile<Tile>(position);
                t_map.SetTileFlags(position, TileFlags.None);
                t_map.SetColor(position, col);
            }

        }


    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            ColorizeMap(dij.getPath(), Color.white);
            dij.ClearPath();
            Vector2 v_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = t_map.WorldToCell(v_mousePosition);

            TileBase clickedTile = t_map.GetTile(gridPosition);

            dij.calculPath(_graph.getNodeByPosition(gridPosition));

            ColorizeMap(dij.getPath(), Color.red);

        }
    }

}