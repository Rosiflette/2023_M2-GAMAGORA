using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    private Renderer apparence;

    // Start is called before the first frame update
    void Start()
    {
        apparence = gameObject.GetComponent<Renderer>();
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            Debug.Log(gameObject.transform.GetChild(i).name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            apparence.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); 
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).name.Contains("Jambe"))
                {
                    GameObject child = gameObject.transform.GetChild(i).gameObject;
                    Vector3 temp = child.transform.localScale;
                    temp.y *= 0.25f;
                    child.transform.localScale = temp;
                }

            }
        }
    }
}
