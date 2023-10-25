using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercice1_Cyclindre : MonoBehaviour
{


    [SerializeField] private Material mat;


    [SerializeField] private float radius = 1;
    [SerializeField] private float height = 1;
    [SerializeField] private int numberOfMeridian;

    List<int> triangles = new List<int>();
    Vector3[] vertices;


    // Start is called before the first frame update
    void Update()
    {
        // angle entre tous les points du cercle

        float angleTeta;
        float x;
        float y = height / 2;
        float z;
        vertices = new Vector3[numberOfMeridian * 2 + 2];

        vertices[0] = new Vector3(0, -y, 0);
        vertices[1] = new Vector3(radius, -y, 0);


        vertices[numberOfMeridian + 1] = new Vector3(0, y, 0);
        vertices[numberOfMeridian + 2] = new Vector3(radius, y, 0);


        for (int i = 1; i < numberOfMeridian; i++)
        {
            angleTeta = 2 * Mathf.PI * i / numberOfMeridian;
            x = Mathf.Cos(angleTeta) * radius;
            z = Mathf.Sin(angleTeta) * radius;
            vertices[i + 1] = new Vector3(x, -y, z);
            vertices[numberOfMeridian + i + 2] = new Vector3(x, y, z);
            

            triangles.Add(0);
            triangles.Add(i);
            triangles.Add(i + 1);

            triangles.Add(numberOfMeridian + i + 2);
            triangles.Add(numberOfMeridian + i + 1);
            triangles.Add(numberOfMeridian + 1);

            triangles.Add(i);
            triangles.Add(numberOfMeridian + i + 1);
            triangles.Add(numberOfMeridian + i + 2);

            triangles.Add(numberOfMeridian + i + 2);
            triangles.Add(i + 1);
            triangles.Add(i);

        }

        triangles.Add(numberOfMeridian);
        triangles.Add(1);
        triangles.Add(0);

        triangles.Add(numberOfMeridian + 1);
        triangles.Add(numberOfMeridian + 2);
        triangles.Add(numberOfMeridian * 2 + 1);


        triangles.Add(numberOfMeridian);
        triangles.Add(numberOfMeridian * 2 + 1);
        triangles.Add(numberOfMeridian + 2);

        triangles.Add(numberOfMeridian + 2);
        triangles.Add(1);
        triangles.Add(numberOfMeridian);

        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();

        Mesh msh = new Mesh();                          // Création et remplissage du Mesh

        msh.vertices = vertices;
        msh.triangles = triangles.ToArray();
        gameObject.GetComponent<MeshFilter>().mesh = msh;           // Remplissage du Mesh et ajout du matériel
        gameObject.GetComponent<MeshRenderer>().material = mat;


    }

}
