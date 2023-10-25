using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice0 : MonoBehaviour
{

    [SerializeField] private Material mat;

    // Use this for initialization
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();

        int width = 10;
        int height = 1;
        int index = 0;

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();


        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                index = (i * height + j) * 4;

                vertices.Add(new Vector3(i, j, 0));
                vertices.Add(new Vector3(i + 1, j, 0));
                vertices.Add(new Vector3(i, j + 1, 0));
                vertices.Add(new Vector3(i + 1, j + 1, 0));

                triangles.Add(index + 0);
                triangles.Add(index + 2);
                triangles.Add(index + 1);

                triangles.Add(index + 2);
                triangles.Add(index + 3);
                triangles.Add(index + 1);
            }
        }

        Mesh msh = new Mesh();                          // Création et remplissage du Mesh

        msh.vertices = vertices.ToArray();
        msh.triangles = triangles.ToArray();

        gameObject.GetComponent<MeshFilter>().mesh = msh;           // Remplissage du Mesh et ajout du matériel
        gameObject.GetComponent<MeshRenderer>().material = mat;
    }
}
