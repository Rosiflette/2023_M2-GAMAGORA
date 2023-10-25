using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreVoiture : MonoBehaviour
{
    private float capacite;
    //définition du constructeur par défaut
    public CoffreVoiture()
    {
        Debug.Log("Constructeur appelé");
        capacite = 0;
    }
    //définition du constructeur alternatif
    public CoffreVoiture(float capaciteCoffre)
    {
        capacite = capaciteCoffre;
        Debug.Log("Constructeur appelé avec : " + capaciteCoffre + " litres");
    }


    ~CoffreVoiture()
    { //définition du destructeur
        Debug.Log("Le coffre de la voiture est maintenant détruit !");
    }
    



}
