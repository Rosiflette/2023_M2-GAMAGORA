using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnumSpatialeQ4Q5 : MonoBehaviour
{

    [SerializeField] int nbSpheres;

    // Start is called before the first frame update
    void Start()
    {
        Grid g = gameObject.GetComponent<Grid>();
        List<CreateSphere> spheres = new List<CreateSphere>();

        for (int j = 0; j < nbSpheres; j++)
        {
            spheres.Add(new CreateSphere(new Vector3(1 * j * 30, 0, 0), 10));
        }


        int i = 0;

        List<Vector3> b;

        foreach (CreateSphere s in spheres)
        {
            b = s.getBox();
            Color c = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            for (float x = b.First().x; x < b.Last().x ; x++)
            {
                for (float y = b.First().y; y < b.Last().y ; y++)
                {
                    for (float z = b.First().z ; z < b.Last().z ; z++)
                    {

                        Vector3 pos = new Vector3(x, y, z);

                        if (!s.IsInside(pos))
                        {
                            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            cube.transform.position = g.LocalToCell(pos);
                            cube.GetComponent<Renderer>().material.color = c;
                        }
                    }
                }
            }
            i++;
        }

    }

}
