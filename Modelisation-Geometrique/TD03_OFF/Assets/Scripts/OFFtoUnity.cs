using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Globalization;
using System;





public class OFFtoUnity : MonoBehaviour
{

    [SerializeField] private UnityEngine.Object file;

    [SerializeField] private string newFileName;
    public static OFFtoUnity Instance { get; private set; }
    private StreamReader content;

    [SerializeField] private Material mat;



    public static StreamReader StreamReaderGetContent()
    {
        return Instance.content;
    }

    Mesh msh;

    // Use this for initialization
    void Start()
    {
        string path = Application.dataPath + "\\Other\\" + file.name + ".off";        

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();
        List<Vector3> normals = new List<Vector3>();

        

        string[] lines = File.ReadAllLines(path);

        string[] parameters = lines[1].Split(' ');

        int numberOFVertices = int.Parse(parameters[0]);



        float medianVX = 0;
        float medianVY = 0;
        float medianVZ = 0;

        float maxVal = 0;

        for (int i = 2; i < lines.Length; i++)
        {
            string[] line = lines[i].Split(' ');

            if (i < numberOFVertices + 2)
            {
                float x = float.Parse(line[0], CultureInfo.InvariantCulture);
                float y = float.Parse(line[1], CultureInfo.InvariantCulture);
                float z = float.Parse(line[2], CultureInfo.InvariantCulture);

                medianVX += x;
                medianVY += y;
                medianVZ += z;

                if (maxVal < Math.Abs(x))
                {
                    maxVal = Math.Abs(x);
                }
                if(maxVal < Math.Abs(y))
                {
                    maxVal = Math.Abs(y);
                }
                if (maxVal < Math.Abs(z))
                {
                    maxVal = Math.Abs(z);
                }

            }
        }


        float medianX = medianVX / numberOFVertices;
        float medianY = medianVY / numberOFVertices;
        float medianZ = medianVZ / numberOFVertices;

        




        for (int i = 2; i < lines.Length; i++)
        {
            string[] line = lines[i].Split(' ');

            if(i < numberOFVertices + 2)
            {
                float x = float.Parse(line[0], CultureInfo.InvariantCulture);
                float y = float.Parse(line[1], CultureInfo.InvariantCulture);
                float z = float.Parse(line[2], CultureInfo.InvariantCulture);
                vertices.Add(new Vector3((x-medianX)/maxVal, (y-medianY)/maxVal, (z-medianZ)/maxVal));
                // vertices.Add(new Vector3(x/10, y/10, z/10));
            }
            else
            {
                int x = int.Parse(line[1]);
                int y = int.Parse(line[2]);
                int z = int.Parse(line[3]);
                triangles.Add(x);
                triangles.Add(y);
                triangles.Add(z);

            }

        }

        for(int i = 0; i < vertices.Count-3; i=i+3)
        {
            normals.Add(CalculateNormal(vertices[i], vertices[i + 1], vertices[i + 2]));
        }

        gameObject.AddComponent<MeshFilter>();          
        gameObject.AddComponent<MeshRenderer>();

        
        
        msh = new Mesh();  

        msh.vertices = vertices.ToArray();
        msh.triangles = triangles.ToArray();

        gameObject.GetComponent<MeshFilter>().mesh = msh;         
        gameObject.GetComponent<MeshRenderer>().material = mat;


        exportOFF(vertices, triangles);


        Debug.Log("Edges : " + getNbEdges());

    }


    public Vector3 CalculateNormal(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        //So for a triangle p1, p2, p3, if the vector A = p2 - p1 and the vector B = p3 - p1 then the normal N = A x B and can be calculated by:

        //Nx = Ay * Bz - Az * By
        //Ny = Az * Bx - Ax * Bz
        //Nz = Ax * By - Ay * Bx


        Vector3 A = p1 - p2;
        Vector3 B = p3 - p1;

        float Nx = A.y * B.z - A.z * B.y;
        float Ny = A.z * B.x - A.x * B.z;
        float Nz = A.x * B.y - A.y * B.x;

        Vector3 normal = new Vector3(Nx, Ny, Nz);

        return normal; 

    }



    public float Normalize(Vector3 vect)
    {
        float temp = vect.x * vect.x + vect.y * vect.y + vect.z * vect.z;
        return MathF.Sqrt(temp);
    }

    //OFF
    //8 12 0
    //0.256 0.365 0.569
    //2.365 2.654 8.145
    public void exportOFF(List<Vector3> vertices, List<int> triangles)
    {
        NumberFormatInfo nfi = new NumberFormatInfo();
        nfi.NumberDecimalSeparator = ".";

        string newFilePath = Application.dataPath + "/Other/" + newFileName + ".off";
        Debug.Log(newFilePath);

        using (StreamWriter outputFile = new StreamWriter(newFilePath))
        {
            outputFile.WriteLine("OFF");
            outputFile.WriteLine(vertices.Count + " " + triangles.Count/3 + " 0");
            for(int i = 0; i < vertices.Count; i++)
            {
                string s = (vertices[i].x.ToString(nfi) + " " + vertices[i].y.ToString(nfi) + " " + vertices[i].z.ToString(nfi));
                outputFile.WriteLine(s);
            }
            for (int i = 0; i < triangles.Count; i=i+3)
            {
                string s = "3 " + triangles[i].ToString(nfi) + " " + triangles[i + 1].ToString(nfi) + " " + triangles[i + 2].ToString(nfi);
                outputFile.WriteLine(s.ToString(nfi));
            }

        }
    }



    struct Edge
    {
        public Vector3 vec1;
        public Vector3 vec2;


        public Edge(Vector3 _vec1, Vector3 _vec2)
        {
            if (_vec1.x < _vec2.x || (_vec1.x == _vec2.x && (_vec1.y < _vec2.y || (_vec1.y == _vec2.y && _vec1.z <= _vec2.z))))
            {
                vec1 = _vec1;
                vec2 = _vec2;
            }
            else
            {
                vec1 = _vec2;
                vec2 = _vec1;
            }

        }



    }

    public int getNbEdges()
    {
        HashSet<Edge> edges = new HashSet<Edge>();
        for (int i = 0; i < msh.triangles.Length; i += 3)
        {
            var pt1 = msh.vertices[msh.triangles[i]];
            var pt2 = msh.vertices[msh.triangles[i + 1]];
            var pt3 = msh.vertices[msh.triangles[i + 2]];
            edges.Add(new Edge(pt1, pt2));
            edges.Add(new Edge(pt1, pt3));
            edges.Add(new Edge(pt2, pt3));
        }
        return edges.Count;
    }


}
