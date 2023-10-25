using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnumSpatialeQ3 : MonoBehaviour
{

    [SerializeField] bool doIntersection;
    [SerializeField] bool doUnion;

    // Start is called before the first frame update
    void Start()
    {
        Grid g = gameObject.GetComponent<Grid>();
        CreateSphere sphere = new CreateSphere(Vector3.zero, 10);
        CreateSphere sphere2 = new CreateSphere(new Vector3(10,1,1), 10);

        List<CreateSphere> spheres = new List<CreateSphere>();
        spheres.Add(sphere);
        spheres.Add(sphere2);
    

        int i = 0;

        i++;
        List<Vector3> b;
        List<Vector3> d;

        b = sphere.getBox();
        d = sphere2.getBox();

            
        for (float x = b.First().x + d.First().x; x < b.Last().x+ d.Last().x; x++)
        {
            for (float y = b.First().y + d.First().y; y < b.Last().y + d.Last().y; y++)
            {
                for (float z = b.First().z + d.First().z; z < b.Last().z + d.Last().z; z++)
                {

                    Vector3 pos = new Vector3(x, y, z);

                    if (doIntersection && !spheres[0].IntersectSpheres(spheres[1], pos))
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = g.LocalToCell(pos);
                        cube.GetComponent<Renderer>().material.SetColor("_Color", Color.green);
                    }
                    
                    if (doUnion && !spheres[0].UnionSpheres(spheres[1], pos))
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.transform.position = g.LocalToCell(pos);
                        cube.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
                    }
                }
            }
        }

    }

}
