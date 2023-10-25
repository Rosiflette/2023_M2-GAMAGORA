using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementMob : MonoBehaviour
{

    [SerializeField]
    private List<GameObject>  cars = new List<GameObject>();


    [SerializeField]
    private float speed;

    private Vector3 forward = new Vector3(0, 0, 1);


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject car in cars)
        {
            car.transform.Translate(forward * speed * Time.deltaTime);

        }

    }
}
