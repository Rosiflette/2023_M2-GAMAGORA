using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private float vitesseDeplacement;
    [SerializeField] float vitesseRotation;
    [SerializeField] MeshRenderer meshGround;
    [SerializeField] SpawnAnimals sp;
    [SerializeField] SpawnFruits sf;
    private float deplacementAxeVertical;
    private float deplacementAxeHorizontal;
    Rigidbody objet_rb;
    int energie = 0;
    int energieVoisin = 0;
    int nbVacheCaught = 0;

    private void Start()
    {
        objet_rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Update()
    {
        deplacementAxeVertical = Input.GetAxis("Vertical");
        deplacementAxeHorizontal = Input.GetAxis("Horizontal");

        if(energieVoisin < 0 || energie < 0 || sp.getNbAnimals() > 10)
        {
            Debug.Log("TU AS PERDUUUUUU");
            sp.stopInvoke();
            sf.stopInvoke();
            
        }

        if(nbVacheCaught > 4)
        {
            Debug.Log("TU AS GAGNEEEEE");
        }
        

    }
    private void FixedUpdate()
    {

        Move();
        Rotation();
    }

    void Move()
    {
        
        Vector3 mouvement = objet_rb.position +transform.forward * deplacementAxeVertical * vitesseDeplacement * Time.deltaTime;
        if(mouvement.x < meshGround.bounds.max.x && mouvement.x > meshGround.bounds.min.x
            && mouvement.z < meshGround.bounds.max.z && mouvement.z > meshGround.bounds.min.z)
        {
            objet_rb.MovePosition(mouvement);
        }

    }

    void Rotation()
    {
        
        objet_rb = GetComponent<Rigidbody>();
        float rotation = deplacementAxeHorizontal * vitesseRotation * Time.deltaTime;
        Quaternion q_rotation = Quaternion.Euler(0f, rotation, 0f);
        objet_rb.MoveRotation(objet_rb.rotation * q_rotation);

    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.tag);
        switch (other.tag){
            case "Banane":
                energie++;
                break;
            case "Poisson":
                gameObject.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
                energieVoisin++;
                break;
            case "Vache":
                nbVacheCaught++;
                energie--;
                break;
            case "Elan":
                energieVoisin--;
                break;

        }

        Debug.Log("Energie : " + energie);
        Debug.Log("EnergieVoisin : " + energieVoisin);
       
    }


}
