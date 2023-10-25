using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionnaireJeu : MonoBehaviour
{
    CoffreVoiture coffreVoiture;

    CoffreVoiture coffreVoitureVoiture;

    // Start is called before the first frame update
    void Start()
    {
        coffreVoiture = new CoffreVoiture();

        coffreVoitureVoiture = new CoffreVoiture(5f);
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.D)))
        {
            coffreVoiture = null;
            coffreVoitureVoiture = null;
        }
    }
}
