using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeplacementsEnnemis : MonoBehaviour
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
        Vector3 nextPos = MapManager.Instance.getNextPosDij(gameObject);
        if (nextPos != Vector3.zero)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPos, speed);
        }

    }
}
