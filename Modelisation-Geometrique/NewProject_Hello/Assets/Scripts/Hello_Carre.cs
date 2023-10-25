using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hello_Carre : MonoBehaviour
{
    [SerializeField]
    private Material mat;

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite �tre visualis�
        gameObject.AddComponent<MeshRenderer>();

        Vector3[] vertices = new Vector3[4];            // Cr�ation des structures de donn�es qui accueilleront sommets et  triangles
        int[] triangles = new int[6];

        vertices[0] = new Vector3(0, 0, 0);            // Remplissage de la structure sommet 
        vertices[1] = new Vector3(1, 0, 0);
        vertices[2] = new Vector3(0, 1, 0);
        vertices[3] = new Vector3(1, 1, 0);

        triangles = new int[] {
            0, 1, 2, // avant bas
            1, 3, 2, // avant haut
            0, 2, 1, // derriere bas
            2, 3, 1 // derrire haut
        };

        Mesh msh = new Mesh();                          // Cr�ation et remplissage du Mesh

        msh.vertices = vertices;
        msh.triangles = triangles;

        gameObject.GetComponent<MeshFilter>().mesh = msh;           // Remplissage du Mesh et ajout du mat�riel
        gameObject.GetComponent<MeshRenderer>().material = mat;
    }
}