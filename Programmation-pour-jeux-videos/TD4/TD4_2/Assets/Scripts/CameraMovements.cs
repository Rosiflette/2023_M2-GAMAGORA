using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
    [SerializeField]
    private Transform carTransform;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = carTransform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = carTransform.position - offset;
        //this.gameObject.transform.position = new Vector3(carTransform.position.x + 15, this.gameObject.transform.position.y, carTransform.position.z);
        //this.gameObject.transform.rotation = Quaternion.Euler(this.transform.rotation.x, carTransform.rotation.y - 90, this.gameObject.transform.rotation.z);
    }
}
