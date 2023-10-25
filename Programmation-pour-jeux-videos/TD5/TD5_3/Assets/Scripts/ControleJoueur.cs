using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleJoueur : MonoBehaviour
{

    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private float rotationSpeed = 100.0f;

    [SerializeField]
    private MeshRenderer ground;

    [SerializeField]
    private GameObject projectile; 


    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed ;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;

        Vector3 nextPosition = gameObject.transform.position + gameObject.transform.forward * translation;
        
        if (ground.bounds.Contains(nextPosition))
        {
            gameObject.transform.Translate(0, 0, translation);
        }

        transform.Rotate(0, rotation, 0);

        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        }



    }
}
