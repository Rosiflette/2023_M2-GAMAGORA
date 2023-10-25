using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{

    [SerializeField]
    private GameObject car;

    private CarHandler carHandler;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float essenceByKm;

    [SerializeField]
    private float rotationY = 0.01f;


    private Vector3 forward = new Vector3(0, 0, 1);

    private Vector3 backward = new Vector3(0, 0, -1);

    // Start is called before the first frame update
    void Start()
    {
        carHandler = new CarHandler();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.LeftArrow))
        {

            car.transform.Rotate(0, -rotationY, 0);
            
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            car.transform.Rotate(0, rotationY, 0);

        }

        if (Input.GetKey(KeyCode.UpArrow)) 
        {
            
            if (carHandler.roule(essenceByKm))
            {
                car.transform.Translate(forward * speed * Time.deltaTime);
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow)) 
        {
            if (carHandler.roule(essenceByKm))
            {
                car.transform.Translate(backward * speed * Time.deltaTime);
            }
        }







    }
}
