using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{
    private int i_x;
    private int i_y;

    private int i_velocityX;
    private int i_velocityY;

    Boids(int x, int y)
    {
        i_x = x;
        i_y = y;
        i_velocityX = Random.Range(1, 10) / 10;
        i_velocityY = Random.Range(1, 10) / 10;

    }

    float Distance()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
