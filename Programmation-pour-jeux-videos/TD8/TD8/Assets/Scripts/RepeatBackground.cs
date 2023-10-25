using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{

    [SerializeField] private GameObject background;
    private Vector3 initialPos;
    private float size;

    // Start is called before the first frame update
    void Start()
    {
        initialPos = background.transform.position;
        size = background.GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {

        float pos = background.transform.position.x;
        
        if (pos <= initialPos.x-size)
        {
            background.transform.position = initialPos;
        }
    }
}
