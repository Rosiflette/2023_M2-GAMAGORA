using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHandler : MonoBehaviour
{
    private double essence;
    public CarHandler()
    { 
        essence = 10;
    }
    public double getEssence()
    {
        return essence;
    }
    public void setEssence(double valeur)
    {
        essence = valeur;
    }
    public bool roule(double consommation)
    {
        setEssence(getEssence() - consommation);
        return getEssence() > 0;
    }

}