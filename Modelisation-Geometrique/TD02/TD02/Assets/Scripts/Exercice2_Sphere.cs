using System.Collections.Generic;
using UnityEngine;

public class Exercice2_Sphere : MonoBehaviour
{
    [SerializeField] private Material mat;
    [SerializeField] private int numberOfParallele;
    [SerializeField] private int numberOfMeridian;
    [SerializeField] private float radius;

    void Start()
    {
        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();
        gameObject.GetComponent<MeshRenderer>().material = mat;
    }

    void Update()
    {
        Mesh msh = gameObject.GetComponent<MeshFilter>().mesh;

        List<Vector3> vertices = new List<Vector3>();

        List<int> triangles = new List<int>();

        for (int j = 1; j < numberOfParallele; j++)
        {
            float phi = Mathf.PI * (j / (float)numberOfParallele);

            for (int i = 0; i < numberOfMeridian; i++)
            {
                float theta = 2 * Mathf.PI * (i / (float)numberOfMeridian);

                float x = radius * Mathf.Sin(phi) * Mathf.Cos(theta);
                float y = radius * Mathf.Cos(phi);
                float z = radius * Mathf.Sin(phi) * Mathf.Sin(theta);

                Vector3 vertex = new Vector3(x, y, z);
                vertices.Add(vertex);
            }
        }


        for (int j = 0; j < numberOfParallele - 2; j++)
        {
            for (int i = 0; i < numberOfMeridian - 1; i++)
            {

                int baseI = i + numberOfMeridian * j;

                triangles.Add(baseI + numberOfMeridian + 1);
                triangles.Add(baseI + numberOfMeridian);
                triangles.Add(baseI);

                triangles.Add(baseI);
                triangles.Add(baseI + 1);
                triangles.Add(baseI + numberOfMeridian + 1);
            }

            int lastI = j * numberOfMeridian + numberOfMeridian - 1;
            int firstI = j * numberOfMeridian;

            triangles.Add(lastI + 1);
            triangles.Add(lastI + numberOfMeridian);
            triangles.Add(lastI);

            triangles.Add(lastI);
            triangles.Add(firstI);
            triangles.Add(lastI + 1);

        }

        vertices.Add(new Vector3(0, -radius, 0));
        vertices.Add(new Vector3(0, radius, 0));

        int southPole = numberOfMeridian * (numberOfParallele - 1);
        int northPole = southPole + 1;

        for (int i = 0; i < numberOfMeridian - 1; i++)
        {
            triangles.Add(i);
            triangles.Add(northPole);
            triangles.Add(i + 1);

            triangles.Add(numberOfMeridian * (numberOfParallele - 2) + i + 1);
            triangles.Add(southPole);
            triangles.Add(numberOfMeridian * (numberOfParallele - 2) + i);
        }

        triangles.Add(numberOfMeridian - 1);
        triangles.Add(northPole);
        triangles.Add(0);

        triangles.Add(numberOfMeridian * (numberOfParallele - 2));
        triangles.Add(southPole);
        triangles.Add(numberOfMeridian * (numberOfParallele - 1) - 1);


        msh.vertices = vertices.ToArray();
        msh.triangles = triangles.ToArray();


    }


}
