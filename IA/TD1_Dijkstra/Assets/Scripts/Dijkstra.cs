using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;


public class Dijkstra 
{


//  1  function Dijkstra(Graph, source):
//  2      
//  3      for each vertex v in Graph.Vertices:
//  4          dist[v] ← INFINITY
//  5          prev[v] ← UNDEFINED
//  6          add v to Q
//  7      dist[source] ← 0
//  8      
//  9      while Q is not empty:
// 10          u ← vertex in Q with min dist[u]
// 11          remove u from Q
// 12          
// 13          for each neighbor v of u still in Q:
// 14              alt ← dist[u] + Graph.Edges(u, v)
// 15              if alt < dist[v]:
// 16                  dist[v] ← alt
// 17                  prev[v] ← u
// 18
// 19      return dist[], prev[]


    private Dictionary<Node, int> dc_distance;
    private Dictionary<Node, Node> dc_prev;
    private List<Node> l_notVisited;

    private List<Node> l_path = new List<Node>();

    

    public Dijkstra(Graph g, Node source){
        dc_distance = new Dictionary<Node, int>();
        dc_prev = new Dictionary<Node, Node>();
        l_notVisited = new List<Node>();

        foreach (Node n in g.getNodes()){
            dc_distance.Add(n, int.MaxValue);
            dc_prev.Add(n, null);
            l_notVisited.Add(n);
            
        }

        dc_distance[source] = 0;


        while(! (l_notVisited.Count < 1)){
            Node currentNode = getMinNode();
            l_notVisited.Remove(currentNode);

            foreach(KeyValuePair<Node, int> neighbor in currentNode.getNeighbors()){
                int sumEdge = dc_distance[currentNode] + neighbor.Value;
                if(sumEdge < dc_distance[neighbor.Key]){
                    dc_distance[neighbor.Key] = sumEdge;
                    dc_prev[neighbor.Key] = currentNode;
                }
            }
        }

    }

    private Node getMinNode(){
        Node minNode = l_notVisited[0];
        foreach (Node n in l_notVisited){
            if(dc_distance[n] < dc_distance[minNode]){
                minNode = n;
            }
        }
        return minNode;
    } 


    public void printPath(Node destination){
        // Debug.Log(" path " + destination.getTile().name +" distance " + dc_distance[destination]);
        // destination.getTile().GetComponent<SpriteRenderer>().color = Color.red;
        Debug.Log(destination);
        l_path.Add(destination);

        if(dc_distance[destination] == 0){
            l_path.Reverse();
            return;
        }
        printPath(dc_prev[destination]);
    }

    public List<Node> getPath(){
        return l_path;
    }





}
