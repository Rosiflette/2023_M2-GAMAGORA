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

    //// Colorier certaines tiles
    // Tile tile = t_map.GetTile<Tile>(position);
    // t_map.SetTileFlags(position, TileFlags.None);
    // t_map.SetColor(position, Color.red);


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
        dij.printPath(_graph.getNodes()[0]);
        ColorizeMap(dij.getPath(), Color.gray);
    }

    private void ColorizeMap(List<Node> path, Color col)
    {
        Tile tile;
        foreach (Node currentNode in path)
        {
            Vector3Int position = currentNode.getPosition();
            tile = t_map.GetTile<Tile>(position);
            t_map.SetTileFlags(position, TileFlags.None);
            t_map.SetColor(position, col);
        }

        tile = t_map.GetTile<Tile>(path[0].getPosition());
        t_map.SetTileFlags(path[0].getPosition(), TileFlags.None);
        t_map.SetColor(path[0].getPosition(), Color.gray);

    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            try
            {
                ColorizeMap(dij.getPath(), Color.white);
                Vector2 v_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3Int gridPosition = t_map.WorldToCell(v_mousePosition);

                TileBase clickedTile = t_map.GetTile(gridPosition);
                
                dij.printPath(_graph.getNodeByPosition(gridPosition));

                ColorizeMap(dij.getPath(), Color.red);
            }
            catch (NullReferenceException)
            {
                Debug.Log("Tile not existing");
            }

            // float speed = dc_dataFromTiles[clickedTile].walkingspeed;
            // print("At position " + gridPosition + " is speed is " + speed);
        }
    }

}


//  public Chunk(Tilemap map)
//     {
//         BoundsInt bounds = map.cellBounds;
//         allTiles = map.GetTilesBlock(bounds);

//         Left = int.MaxValue;
//         Right = int.MaxValue;

//         Height = bounds.size.y;
//         Width = bounds.size.x;

//         for (int x = 0; x < Width; x++)
//         {
//             for (int y = 0; y < Height; y++)
//             {
//                 TileBase tile = allTiles[x + y * Width];
//                 if (tile != null && Left == int.MaxValue)
//                 {
//                     Left = x;
//                     Top = y;
//                 }
//             }
//         }

//         for (int x = Width - 1; x >= 0; x--)
//         {
//             for (int y = Height - 1; y >= 0; y--)
//             {
//                 TileBase tile = allTiles[x + y * Width];
//                 if (tile != null && Right == int.MaxValue)
//                 {
//                     Right = x;
//                     Bottom = y;
//                 }
//             }
//         }

//         InnerLeft = int.MaxValue;
//         InnerRight = int.MaxValue;
//         // inner bounds
//         for (int x = 0; x < Width; x++)
//         {

//             for (int y = 0; y < Height; y++)
//             {
//                 TileBase tile = allTiles[x + y * Width];
//                 if (tile == null 
//                     && x > Left && x < Right 
//                     && y > Top && y < Bottom
//                     && InnerLeft == int.MaxValue)
//                 {
//                     InnerLeft = x;
//                     InnerTop = y;
//                 }
//             }
//         }

//         for (int x = Width - 1; x >= 0; x--)
//         {
//             for (int y = Height - 1; y >= 0; y--)
//             {
//                 TileBase tile = allTiles[x + y * Width];
//                 if (tile == null 
//                     && x > Left && x < Right
//                     && y > Top && y < Bottom
//                     && InnerRight == int.MaxValue)
//                 {
//                     InnerRight = x;
//                     InnerBottom = y;
//                 }
//             }
//         }

//         InnerWidth = Mathf.Abs(InnerLeft - InnerRight);
//         InnerHeight = Mathf.Abs(InnerTop - InnerBottom) + 1;
//     }
// }



// foreach (TileBase tile in t_map.GetTilesBlock(t_map.cellBounds))
// {
//     if (tile != null)
//     {
//         tile.GetTileData()
//         Debug.Log("Tile at position " + position + " is " + tile.name);
//         _graph.Add(tile, new Node(tile, position));

//     }
// }




// for (int x = _bounds.x; x < _bounds.x + _bounds.size.x; x++)
// {
//     for (int y = _bounds.y; y < _bounds.y + _bounds.size.y; y++)
//     {
//         // print(x);


//         Vector3Int cellPosition = new Vector3Int(x, y, 0);
//         Vector3Int gridPosition = t_map.WorldToCell(cellPosition);

//         TileBase tile = t_map.GetTile(gridPosition);


//         if (tile != null)
//         {
//         print(cellPosition);
//             // print(x + " " + y);
//             tile.name = $"{x},{y}";

//             // print("pos : " + cellPosition);
//             _graph.Add(tile, new Node(tile, cellPosition));

//         }
//     }
// }