using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleVie : MonoBehaviour
{

    private CoffreVoiture cv;

    // Si le script est attaché à un objet : Awake sera appelé même si il n'est pas activé
    private void Awake()
    {
        Debug.Log("« La voiture se réveille »");
    }

     // Si le script est attaché à l'objet, le start est appelé mais s'il n'est pas activé, alors pass appelé
    private void Start()
    {
        Debug.Log("« La voiture finit son paramétrage juste avant son utilisation »");
        cv = new CoffreVoiture();

    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            // Détruit le gameObject sur lequel se trouve le script
            Destroy(gameObject);

            // Détruit le script en lui même
            Destroy(this);
        }
    }


    private void OnDestroy()
    {
        
        Debug.Log("« La voiture est en voie de destruction »");
    }


}
