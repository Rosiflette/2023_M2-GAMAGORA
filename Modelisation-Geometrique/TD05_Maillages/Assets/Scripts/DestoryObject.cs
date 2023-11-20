using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryObject : MonoBehaviour
{

    public float speed = 10.0f;


    void Update()
    {
        float translationVertical = Input.GetAxis("Vertical") * speed;
        float translationHorizontal = Input.GetAxis("Horizontal") * speed;

        translationVertical *= Time.deltaTime;
        translationHorizontal *= -Time.deltaTime;

        if(Input.GetKey(KeyCode.Space))
        {
            transform.Translate(translationHorizontal, translationVertical, -2f*Time.deltaTime);
        }
        else
        {

        transform.Translate(translationHorizontal, translationVertical, 0);
        }


    }
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
