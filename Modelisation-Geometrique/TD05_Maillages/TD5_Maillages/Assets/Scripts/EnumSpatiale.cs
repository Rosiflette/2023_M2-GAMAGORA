using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnumSpatiale : MonoBehaviour
{

    
    
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

        foreach(CreateSphere s in spheres)
        {
            i++;
            List<Vector3> b;
            if (i == 1)
            {
            b = sphere.getBox();

            }
            else
            {

            b = sphere2.getBox();
            }
            for (float x = b.First().x; x < b.Last().x; x++)
            {
                for (float y = b.First().y; y < b.Last().y; y++)
                {
                    for (float z = b.First().z; z < b.Last().z; z++)
                    {

                        Vector3 pos = new Vector3(x, y, z);

                        if (!s.IsInside(pos))
                        {
                            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            cube.transform.position = g.LocalToCell(pos);
                            if(i == 2)
                            {
                                cube.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
                            }
                        }
                    }
                }
            }
        }





    }


}
