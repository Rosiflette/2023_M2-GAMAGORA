using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacements : MonoBehaviour
{
    [SerializeField] float f_speed;

    // Update is called once per frame
    void Update()
    {
        float f_verticalMovement = Input.GetAxis("Vertical");
        float f_horizontalMovement = Input.GetAxis("Horizontal");

        Vector3 v_move = new Vector3(f_horizontalMovement, f_verticalMovement, 0) * Time.deltaTime * f_speed;

        gameObject.transform.Translate(v_move);
    }
}
