using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{
    [SerializeField] public float vitesse;
    public float max;
    public float min;
    private bool topToBot;

    // Start is called before the first frame update
    void Start()
    {
        topToBot = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nextPos = gameObject.transform.position + new Vector3(0, 0, 1) * vitesse * Time.deltaTime;
        if (nextPos.z > max)
        {
            topToBot = false;
        }
        if (nextPos.z < min)
        {
            topToBot = true;
        }

        if (topToBot)
        {
            gameObject.transform.position += new Vector3(0, 0, 1) * vitesse * Time.deltaTime;
        }
        else
        {
            gameObject.transform.position -= new Vector3(0, 0, 1) * vitesse * Time.deltaTime;
        }
    }
}
