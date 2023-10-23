using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using System; 
  
class MainClass : MonoBehaviour { 
  
    // Main Method 
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
 
        Graph Cities = new Graph();

        Node NewYork = new Node("New York");
        Node Miami = new Node("Miami");
        Node Chicago = new Node("Chicago");

        Cities.Add(NewYork);
        Cities.Add(Miami);
        Cities.Add(Chicago);

        NewYork.AddNeighbor(Miami, 1);
        
        Miami.AddNeighbor(Chicago, 1);

        

        Dijkstra c = new Dijkstra(Cities, NewYork);
        Chicago.getName();
        c.printPath(Chicago);
    
    } 
} 

