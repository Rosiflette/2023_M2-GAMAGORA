using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionCollision : MonoBehaviour
{
    [SerializeField] private float vitesseDeplacement;
    [SerializeField] private float vitesseRotation;
    private float deplacementAxeVertical;
    private float deplacementAxeHorizontal;
    Rigidbody objet_rb;
    private int isEatable = 0;

    void Start()
    {
        objet_rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        deplacementAxeVertical = Input.GetAxis("Vertical");
        deplacementAxeHorizontal = Input.GetAxis("Horizontal");

        if (!Input.anyKey)
        {
            objet_rb.velocity = Vector3.zero;
            objet_rb.angularVelocity = Vector3.zero;
        }

    }


    private void FixedUpdate()
    {
        deplacement();
        rotation();
    }


    private void deplacement()
    {
        Vector3 mouvement = new Vector3(deplacementAxeHorizontal , 0, deplacementAxeVertical).normalized * vitesseDeplacement * Time.deltaTime;
        objet_rb.MovePosition(objet_rb.position + mouvement);
    }


    private void rotation()
    {
        // implémentation de la méthode « rotation » ;
        
        //Rigidbody objet_rb = GetComponent<Rigidbody>();
        //objet_rb = GetComponent<Rigidbody>();
        //float rotation = deplacementAxeHorizontal * vitesseRotation * Time.deltaTime;
        //Quaternion q_rotation = Quaternion.Euler(0f, rotation, 0f);
        //objet_rb.MoveRotation(objet_rb.rotation * q_rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Capsule" )
        {
            isEatable ++;
            Destroy(other.gameObject);
            gameObject.transform.localScale *= 2;
        }
        

        if(other.tag == "Obstacle")
        {
            if (isEatable>0)
            {
                Destroy(other.gameObject);
                isEatable --;

            }
            else
            {
                other.gameObject.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        

        //if (other.gameObject)
        //if()
        //{
        //    other.gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        //}
        //else
        //{
        //    other.gameObject.GetComponent<Renderer>().material.color = Color.red;
            
        //    gameObject.transform.localScale *= 2;
        //}
        

    }

    private void OnTriggerExit(Collider other)
    {


        other.gameObject.GetComponent<Renderer>().material.color = Color.white;
        


    }
}
