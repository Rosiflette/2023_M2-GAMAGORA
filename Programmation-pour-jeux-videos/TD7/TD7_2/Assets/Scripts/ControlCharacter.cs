using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{

    private Rigidbody instanceRigidBody;

    [SerializeField] float force = 20f;
    [SerializeField] float gravity = 3;
    private bool isColliding;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        instanceRigidBody = gameObject.GetComponent<Rigidbody>();
        Physics.gravity *= gravity;
    }

    // Update is called once per frame
    void Update()
    {
        


        if (isGameOver)
        {
            Debug.Log("Game Over");

        }
        else{
            if (Input.GetKeyDown(KeyCode.Space) && isColliding)
            {
                jump();
            }
        }

    }

    void jump()
    {
        instanceRigidBody.AddForce(transform.up * force, ForceMode.Acceleration) ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isColliding = true;
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            isGameOver = true;
        }


    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isColliding = false;
        }
    }

}
