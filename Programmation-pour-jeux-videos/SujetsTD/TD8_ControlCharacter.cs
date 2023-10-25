using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCharacter : MonoBehaviour
{

    private Rigidbody instanceRigidBody;

    [SerializeField] float force = 20f;
    [SerializeField] float gravity = 3;
    [SerializeField] private ParticleSystem particuleExplosion;
    [SerializeField] private ParticleSystem particulePoussieres;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioSource audio;


    private bool isColliding;
    private bool isGameOver = false;


    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        instanceRigidBody = gameObject.GetComponent<Rigidbody>();
        Physics.gravity *= gravity;
        anim = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {


        if (isGameOver)
        {
            Debug.Log("Game Over");
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 2);
            

        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && isColliding)
            {
                jump();

            }

        }

    }

    void jump()
    {
        instanceRigidBody.AddForce(transform.up * force, ForceMode.Acceleration) ;
        anim.SetTrigger("Jump_trig");
        audio.PlayOneShot(jumpSound);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isColliding = true;
            particulePoussieres.Play();
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            isGameOver = true;
            particuleExplosion.Play();
            audio.PlayOneShot(crashSound);
            particulePoussieres.Stop();
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
            particulePoussieres.Stop();
        }
    }

}
