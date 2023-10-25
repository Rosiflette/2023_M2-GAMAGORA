using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testOperationVector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector2 vec1 = new Vector2(5, 8);
        Vector2 vec2 = new Vector2(3, 2);
        Debug.Log(vec1 + vec2);

        Vector2 vec3 = new Vector2(-1, -3);
        Vector2 vec4= new Vector2(-2, 2);
        Debug.Log(vec3 - vec4);


        Vector3 vec5 = new Vector3(-2, -1, 5);
        Vector3 vec6 = new Vector3(1, 4, 3);
        Debug.Log(vec5 + vec6);

        Vector3 vec7 = new Vector3(2, -4, 1);
        Vector3 vec8 = new Vector3(-1, -1, 3);

        Debug.Log(vec7 - vec8);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
