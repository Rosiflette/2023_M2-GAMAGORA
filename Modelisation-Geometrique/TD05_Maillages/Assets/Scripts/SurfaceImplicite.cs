using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceImplicite : MonoBehaviour
{
    CreateSphere s = new CreateSphere(new Vector3(0,0,0), 3);
    [SerializeField] GameObject pref;

    // Start is called before the first frame update
    void Start()
    {
        Grid g = gameObject.GetComponent<Grid>();
        for (int x = 0; x < 10; x++)
        {
            for(int y = 0; y < 10; y++)
            {
                for(int z = 0; z < 10; z++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    //GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    Instantiate(pref, g.LocalToCell(pos), Quaternion.identity);
                    //cube.transform.position = g.LocalToCell(pos);
                    //cube.AddComponent<ManageCube>

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
