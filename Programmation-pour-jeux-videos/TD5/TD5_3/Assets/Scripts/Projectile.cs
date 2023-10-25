using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed;
    
    void Start()
    {
        
    }

    void Update()
    {
            gameObject.transform.Translate(0, 0, speed);
    }
}
