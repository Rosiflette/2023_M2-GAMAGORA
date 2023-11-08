using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class MapManager : MonoBehaviour
{
    #region Singleton
    // La référence statique au singleton
    private static MapManager _instance;
    public static MapManager Instance
    {
        get
        {
            // Si l'instance n'existe pas, tentez de la trouver dans la scène
            if (_instance == null)
            {
                _instance = FindObjectOfType<MapManager>();

                // Si l'instance n'a pas été trouvée dans la scène, créez-la
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("MapManagerSingleton");
                    _instance = singletonObject.AddComponent<MapManager>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
    #endregion

    [SerializeField] private Tilemap t_map;
    [SerializeField] private List<TileData> l_typesTile;

    [SerializeField] private GameObject go_character;
    [SerializeField] private List<GameObject> go_ennemis;


    [SerializeField] private GameObject fruitPrefab;
    private Dictionary<TileBase, TileData> dc_dataFromTiles;
    private Graph g_graph = new Graph();
    private Dijkstra dij;

    private AStar astar;

    private bool b_isFruitExist = false;

    private GameObject currentFruit;




    void Start()
    {
        dc_dataFromTiles = new Dictionary<TileBase, TileData>();
        foreach (TileData typeTile in l_typesTile)
        {
            foreach (TileBase tile in typeTile.tiles)
            {
                dc_dataFromTiles.Add(tile, typeTile);
            }

        }
        BoundsInt _bounds = t_map.cellBounds;
        foreach (Vector3Int position in _bounds.allPositionsWithin)
        {
            Tile tile = t_map.GetTile<Tile>(position);
            if (tile != null)
            {
                g_graph.Add(position, new Node(position, dc_dataFromTiles[tile]));
            }
        }

        foreach (Node nodeDic in g_graph.getNodes())
        {

            Vector3Int v = nodeDic.getPosition();

            Vector3Int top = new Vector3Int(v.x, v.y + 1, v.z);
            Vector3Int bottom = new Vector3Int(v.x, v.y - 1, v.z);
            Vector3Int left = new Vector3Int(v.x + 1, v.y, v.z);
            Vector3Int right = new Vector3Int(v.x - 1, v.y, v.z);

            Vector3Int topLeft = new Vector3Int(v.x + 1, v.y + 1, v.z);
            Vector3Int topRight = new Vector3Int(v.x - 1, v.y + 1, v.z);
            Vector3Int botLeft = new Vector3Int(v.x + 1, v.y - 1, v.z);
            Vector3Int botRight = new Vector3Int(v.x - 1, v.y - 1, v.z);

            Node neighborTop = g_graph.getNodeByPosition(top);
            if (neighborTop != null)
            {
                nodeDic.AddNeighbor(neighborTop, 2);
            }
            Node neighborBot = g_graph.getNodeByPosition(bottom);
            if (neighborBot != null)
            {
                nodeDic.AddNeighbor(neighborBot, 2);

            }
            Node neighborRight = g_graph.getNodeByPosition(right);
            if (neighborRight != null)
            {
                nodeDic.AddNeighbor(neighborRight, 2);
            }
            Node neighborLeft = g_graph.getNodeByPosition(left);
            if (neighborLeft != null)
            {
                nodeDic.AddNeighbor(neighborLeft, 2);
            }
            // Pour les diagonales mettre +1
            Node neighborTopLeft = g_graph.getNodeByPosition(topLeft);
            if (neighborTopLeft != null && neighborTop != null && neighborLeft != null)
            {
                nodeDic.AddNeighbor(neighborTopLeft, 3);
            }
            Node neighborTopRight = g_graph.getNodeByPosition(topRight);
            if (neighborTopRight != null && neighborTop != null && neighborRight != null)
            {
                nodeDic.AddNeighbor(neighborTopRight, 3);
            }
            Node neighborBotLeft = g_graph.getNodeByPosition(botLeft);
            if (neighborBotLeft != null && neighborBot != null && neighborLeft != null)
            {
                nodeDic.AddNeighbor(neighborBotLeft, 3);
            }
            Node neighborBotRight = g_graph.getNodeByPosition(botRight);
            if (neighborBotRight != null && neighborBot != null && neighborRight != null)
            {
                nodeDic.AddNeighbor(neighborBotRight, 3);
            }
        }


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
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !b_isFruitExist)
        {
            Vector2 v_mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int gridPosition = t_map.WorldToCell(v_mousePosition);
            currentFruit = Instantiate(fruitPrefab, t_map.GetCellCenterWorld(gridPosition), Quaternion.identity);
            b_isFruitExist = true;
        }
        if (b_isFruitExist)
        {
            CharacterDirection();
        }
        EnnemyDirection();

    }


    // Dijsktra utilisation
    private void EnnemyDirection()
    {

        Vector3Int _ennemiPosition = t_map.WorldToCell(go_ennemis[0].transform.position);
        Node startNode = g_graph.getNodeByPosition(_ennemiPosition);
        if (startNode != null)
        {
            if (dij != null)
            {
                ColorizeMap(dij.getPath(), Color.white);
                dij.ClearPath();
            }

            dij = new Dijkstra(g_graph, startNode);
            Vector2 _charPos = go_character.transform.position;
            Vector3Int _characterPosition = t_map.WorldToCell(_charPos);
            dij.calculPath(g_graph.getNodeByPosition(_characterPosition));
            ColorizeMap(dij.getPath(), Color.red);
        }
    }

    // Astar utilisation
    private void CharacterDirection()
    {

        Vector3Int _ennemiPosition = t_map.WorldToCell(currentFruit.transform.position);
        Node startNode = g_graph.getNodeByPosition(_ennemiPosition);
        if (startNode != null)
        {
            if (astar != null)
            {
                ColorizeMap(astar.getPath(), Color.white);
                astar.ClearPath();
            }

            Vector2 _charPos = go_character.transform.position;
            Vector3Int _characterPosition = t_map.WorldToCell(_charPos);
            astar = new AStar(g_graph, startNode, g_graph.getNodeByPosition(_characterPosition));
            ColorizeMap(astar.getPath(), Color.blue);
        }
    }


    public Vector3 getNextPosDij(GameObject en)
    {
        if(dij != null)
        {
            if (dij.getPath().Count > 1)
            {
                return t_map.GetCellCenterWorld(dij.getPath()[1].getPosition());
            }
        }
        return new Vector3(0, 0, 0);
    }




    public Vector3 getNextPosAStar(GameObject en)
    {
        if (astar != null)
        {
            if (astar.getPath().Count > 1)
            {
                return t_map.GetCellCenterWorld(astar.getPath()[1].getPosition());
            }
        }
        return new Vector3(0, 0, 0);
    }


    public void IsFruitExisting(bool b)
    {
        b_isFruitExist = b;
    }







}