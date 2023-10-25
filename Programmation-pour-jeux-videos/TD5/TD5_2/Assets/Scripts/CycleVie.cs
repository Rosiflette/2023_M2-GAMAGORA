using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleVie : MonoBehaviour
{

    private CoffreVoiture cv;

    // Si le script est attach� � un objet : Awake sera appel� m�me si il n'est pas activ�
    private void Awake()
    {
        Debug.Log("� La voiture se r�veille �");
    }

     // Si le script est attach� � l'objet, le start est appel� mais s'il n'est pas activ�, alors pass appel�
    private void Start()
    {
        Debug.Log("� La voiture finit son param�trage juste avant son utilisation �");
        cv = new CoffreVoiture();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            // D�truit le gameObject sur lequel se trouve le script
            Destroy(gameObject);

            // D�truit le script en lui m�me
            Destroy(this);
        }
    }


    private void OnDestroy()
    {
        
        Debug.Log("� La voiture est en voie de destruction �");
    }


}
