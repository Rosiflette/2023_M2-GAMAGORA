using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeplacementsAllier : MonoBehaviour
{

    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
        speed = speed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 nextPos = MapManager.Instance.getNextPosAStar(gameObject);
        if (nextPos != Vector3.zero)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPos, speed);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        Debug.Log("Collision");
        Destroy(other.gameObject);
    }

    
}
