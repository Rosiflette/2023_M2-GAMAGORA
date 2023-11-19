using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class BoidsManager : MonoBehaviour
{
    [SerializeField] private int nbBoids;
    [SerializeField] private GameObject boidPrefab;
    [SerializeField] private Vector3 initialPosition = new Vector3();
    [SerializeField] private float vlim;
    [SerializeField] private float spaceBetween;
    [SerializeField] private float catchUpVelocity;
    [SerializeField] private float returnInRectangleVelocity;
    [SerializeField] private Vector3 minPos;
    [SerializeField] private Vector3 maxPos;

    List<Boid> l_boids = new List<Boid>();

    // Start is called before the first frame update
    void Start()
    {
        initialise_positions();

    }

    // Update is called once per frame
    void Update()
    {

        move_all_boids_to_new_positions();

    }

    void initialise_positions()
    {
        for (int i = 0; i < nbBoids; i++)
        {
            GameObject boidObject = Instantiate(boidPrefab, initialPosition, Quaternion.identity);
            boidObject.GetComponent<Boid>().velocity = new Vector3(Random.Range(0f,1f), Random.Range(0f,1f), 0);
            l_boids.Add(boidObject.GetComponent<Boid>());
            
        }
    }

    void move_all_boids_to_new_positions()
    {
        Vector3 v1, v2, v3, v4 = new Vector3();

        foreach (Boid b in l_boids)
        {
            v1 = rule1(b);
            v2 = rule2(b);
            v3 = rule3(b);
            v4 = bound_position(b);

            b.velocity = b.velocity + v1 + v2 + v3 + v4;
            limit_velocity(b);
            b.setPosition(b.getPosition() + b.velocity);

        }
    }

    Vector3 rule1(Boid bj)
    {
        Vector3 pcj = new Vector3();

        foreach (Boid b in l_boids)
        {
            if (b != bj)
            {
                pcj = pcj + b.getPosition();
            }
        }
        float N = l_boids.Count; // A VERIFIER
        pcj = pcj / (N - 1);

        return (pcj - bj.getPosition()) / 100;
    }

    Vector3 rule2(Boid bj)
    {
        Vector3 c = Vector3.zero;

        foreach (Boid b in l_boids)
        {
            if (b != bj)
            {
                
                if ((b.getPosition() - bj.getPosition()).magnitude < spaceBetween)
                {
                    c = c - (b.getPosition() - bj.getPosition());
                }

            }
        }

        return c;

    }

    Vector3 rule3(Boid bj)
    {
        Vector3 pvj = new Vector3();

        foreach (Boid b in l_boids)
        {
            if (b != bj)
            {
                pvj = pvj + b.velocity;
            }

        }
        float N = l_boids.Count; // A VERIFIER
        pvj = pvj / (N - 1);

        return (pvj - bj.velocity) / catchUpVelocity; // Vitesse à laquelle il va rejoindre les autres
    }

    void limit_velocity(Boid b)
    {
        float vlimNormalized = vlim / 1000;
        // Vector3 v = new Vector3(); // A QUOI SERT LE VECTOR V ??
        if (b.velocity.magnitude > vlimNormalized)
        {
            b.velocity = (b.velocity / b.velocity.magnitude) * vlimNormalized;
        }
    }


    Vector3 bound_position(Boid b){
        Vector3 v = new Vector3();
        if(b.getPosition().x < minPos.x){
            v.x = returnInRectangleVelocity;
        }
        else if (b.getPosition().x > maxPos.x){
            v.x = -returnInRectangleVelocity;
        }

        if(b.getPosition().y < minPos.y){
            v.y = returnInRectangleVelocity;
        }
        else if(b.getPosition().y > maxPos.y){
            v.y = -returnInRectangleVelocity;
        }

        if(b.getPosition().z < minPos.z){
            v.z = returnInRectangleVelocity;
        }
        else if (b.getPosition().z > maxPos.z){
            v.z = -returnInRectangleVelocity;
        }
        return v;
    }



}
