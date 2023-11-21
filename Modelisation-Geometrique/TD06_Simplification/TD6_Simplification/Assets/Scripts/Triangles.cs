using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Triangle
{
    public Transform vecteur1;
    public Transform vecteur2;
    public Transform vecteur3;
}

public class Triangles : MonoBehaviour
{
    
    [SerializeField] List<Triangle> listTriangles; 
    [SerializeField] Material mat;

    public Color gridColor = Color.red;
    public int gridStartSizeX = -5;
    public int gridSizeX = 5;
    public int gridStartSizeY = -5;
    public int gridSizeY = 5;

    private void OnDrawGizmos()
    {
        Gizmos.color = gridColor;

        float cellSizeX = GetComponent<Grid>().cellSize.x;
        float cellSizeY = GetComponent<Grid>().cellSize.y;

        for (int i = gridStartSizeX; i <= gridSizeX; i++)
        {
            float xPos = i * cellSizeX;
            Vector3 start = new Vector3(xPos, gridStartSizeY * cellSizeY, 0);
            Vector3 end = new Vector3(xPos, gridSizeY * cellSizeY, 0);
            Gizmos.DrawLine(start, end);
        }

        for (int j = gridStartSizeY; j <= gridSizeY; j++)
        {
            float yPos = j * cellSizeY;
            Vector3 start = new Vector3(gridStartSizeX * cellSizeX, yPos, 0);
            Vector3 end = new Vector3(gridSizeX * cellSizeX, yPos, 0);
            Gizmos.DrawLine(start, end);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<MeshFilter>();          // Creation d'un composant MeshFilter qui peut ensuite être visualisé
        gameObject.AddComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        DrawTriangles();
        Debug.Log(isInSameCell(listTriangles[0].vecteur1, listTriangles[0].vecteur2));

        if (Input.GetKey(KeyCode.Escape))
        {
            if(isInSameCell(listTriangles[0].vecteur1, listTriangles[0].vecteur2)){
                //fusePoints(0, listTriangles[0].vecteur2);
            }
        }
    }

    void fusePoints(int indTriangle1, int indTriangle2)
    {

    }

    bool isInSameCell(Transform element1, Transform element2)
    {

        Vector3Int cellPosition1 = gameObject.GetComponent<Grid>().WorldToCell(element1.position);
        Vector3Int cellPosition2 = gameObject.GetComponent<Grid>().WorldToCell(element2.position);
        return cellPosition1 == cellPosition2;
    }


    void DrawTriangles()
    {

        List<Vector3> vertices = new List<Vector3>();
        List<int> triangles = new List<int>();


        int indice = 0;

        foreach (Triangle p in listTriangles)
        {
            vertices.Add(p.vecteur1.position);
            vertices.Add(p.vecteur2.position);
            vertices.Add(p.vecteur3.position);

            triangles.Add(indice++);
            triangles.Add(indice++);
            triangles.Add(indice++);

        }


        Mesh msh = new Mesh();                          // Création et remplissage du Mesh

        msh.vertices = vertices.ToArray();
        msh.triangles = triangles.ToArray();

        gameObject.GetComponent<MeshFilter>().mesh = msh;           // Remplissage du Mesh et ajout du matériel
        gameObject.GetComponent<MeshRenderer>().material = mat;

    }



}
