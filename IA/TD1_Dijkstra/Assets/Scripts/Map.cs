using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    [SerializeField] private int width;
    [SerializeField] private int height;

    [SerializeField] private GameObject tilePrefab;

    private List<GameObject> tiles;

    private void CreateGround()
    {
        for(int x = 0; x < width; x++)
        {
            for(int y =  0; y < height; y++)
            {
                GameObject newTile = Instantiate(tilePrefab, new Vector2(x, y), Quaternion.identity);
                newTile.name = $"tile{x}{y}";
                tiles.Add(newTile);
            }
        }
    }

    void Start()
    {
        tiles = new List<GameObject>();
        CreateGround();
    }

    void Update()
    {
        
    }
}
