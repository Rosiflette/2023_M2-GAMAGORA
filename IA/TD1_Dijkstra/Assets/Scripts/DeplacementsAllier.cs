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
        speed = speed * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 nextPos = MapManager.Instance.getNextPosAStar(gameObject);
        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPos, speed);
    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        MapManager.Instance.IsFruitExisting(false);
        Destroy(other.gameObject);
        
    }


}
