using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class incrementScale : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private GameObject cube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cube.transform.Translate( Vector3.forward * speed * Time.deltaTime);
        cube.transform.Rotate(new Vector3(0, 45, 0) * Time.deltaTime);

    }
}
