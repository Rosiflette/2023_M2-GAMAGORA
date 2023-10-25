using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_Cube : MonoBehaviour
{
    [SerializeField]
    private Material mat;

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[8];            // Création des structures de données qui accueilleront sommets et  triangles
        int[] triangles = new int[6];

        vertices[0] = new Vector3(0, 0, 0);            // Remplissage de la structure sommet 
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 1, 0);
        vertices[3] = new Vector3(1, 1, 0);
        vertices[4] = new Vector3(0, 1, 1);
        vertices[5] = new Vector3(1, 1, 1);
        vertices[6] = new Vector3(1, 0, 1);
        vertices[7] = new Vector3(0, 0, 1);

        triangles = new int[] {
            0, 2, 1, // avant bas
            2, 3, 1, // avant haut
            2, 4, 3,
            3, 4, 5,
            6, 5, 4,
            4, 7, 6,
            1, 7, 0,
            6, 7, 1,
            1, 3, 6,
            3, 5, 6,
            0, 7, 2,
            7, 4, 2,
        };

        Mesh msh = new Mesh();                          // Création et remplissage du Mesh

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;           // Remplissage du Mesh et ajout du matériel
        gameObject.GetComponent<MeshRenderer>().material = mat;
    }
}