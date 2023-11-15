using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    [SerializeField] private Transform character;
    [SerializeField] private float smoothTime;

    Vector3 velocity = Vector3.zero;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 camPos = Vector3.SmoothDamp(gameObject.transform.position, character.position, ref velocity, smoothTime);
        gameObject.transform.position = new Vector3(camPos.x, camPos.y, -10);
    
    }
}
