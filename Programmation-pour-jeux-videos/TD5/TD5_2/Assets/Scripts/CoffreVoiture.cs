using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffreVoiture : MonoBehaviour
{
    private float capacite;
    //d�finition du constructeur par d�faut
    public CoffreVoiture()
    {
        Debug.Log("Constructeur appel�");
        capacite = 0;
    }
    //d�finition du constructeur alternatif
    public CoffreVoiture(float capaciteCoffre)
    {
        capacite = capaciteCoffre;
        Debug.Log("Constructeur appel� avec : " + capaciteCoffre + " litres");
    }


    ~CoffreVoiture()
    { //d�finition du destructeur
        Debug.Log("Le coffre de la voiture est maintenant d�truit !");
    }
    



}
