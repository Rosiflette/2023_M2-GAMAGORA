using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

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
    [SerializeField] private List<Vector3> attractions;
    [SerializeField] private int attractionForce;
    [SerializeField] private Transform characterPos;
    [SerializeField] private float repulsionForce;
    [SerializeField] private float distanceToCharacter;

    List<Boid> l_boids = new List<Boid>();




    // Start is called before the first frame update
    void Start()
    {
        attractions = MapManager.Instance.getSlowTilePosition();
        initialise_positions();
    }

    // Update is called once per frame
    void Update()
    {

        foreach (Boid b in l_boids)
        {

            if (Vector3.Distance(b.getPosition(), characterPos.position) < distanceToCharacter)
            {
                b.currentState = StateMachine.State.runAway;
            }
            else
            {
                b.currentState = StateMachine.State.move;
            }

            switch (b.currentState)
            {
                case StateMachine.State.move:
                    move_boid_to_new_positions(b, false);
                    break;
                case StateMachine.State.gameLose:
                    break;
                case StateMachine.State.runAway:
                    move_boid_to_new_positions(b, true);

                    break;
                default:
                    break;
            }

        }

    }

    void initialise_positions()
    {
        for (int i = 0; i < nbBoids; i++)
        {
            GameObject boidObject = Instantiate(boidPrefab, initialPosition, Quaternion.identity);
            boidObject.GetComponent<Boid>().velocity = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0);
            l_boids.Add(boidObject.GetComponent<Boid>());

        }
    }

    void move_boid_to_new_positions(Boid b, bool isFlyAway)
    {
        Vector3 v1 = new Vector3();

        List<Boid> neighbors = new List<Boid>();

        foreach (Boid boid in l_boids)
        {
            if (Vector3.Distance(boid.getPosition(), b.getPosition()) < 0.1)
            {
                neighbors.Add(boid);
            }
        }
        

        v1 = rule1(b, neighbors);
        v1 += rule2(b, neighbors);
        v1 += rule3(b, neighbors);
        //v1 += bound_position(b);
        v1 += tend_to_place(b);
        if (isFlyAway)
        {
            v1 += away_from_place(b);
        }

        b.velocity = b.velocity + v1;
        limit_velocity(b);
        b.setPosition(b.getPosition() + b.velocity*30 * Time.deltaTime);

    }

    Vector3 rule1(Boid bj, List<Boid> listBoid)
    {
        Vector3 pcj = new Vector3();

        foreach (Boid b in listBoid)
        {
            if (b != bj)
            {
                pcj = pcj + b.getPosition();
            }
        }
        float N = l_boids.Count;
        pcj = pcj / (N - 1);

        return (pcj - bj.getPosition()) / 1000;
    }

    Vector3 rule2(Boid bj, List<Boid> listBoid)
    {
        Vector3 c = Vector3.zero;

        foreach (Boid b in listBoid)
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

    Vector3 rule3(Boid bj, List<Boid> listBoid)
    {
        Vector3 pvj = new Vector3();

        foreach (Boid b in listBoid)
        {
            if (b != bj)
            {
                pvj = pvj + b.velocity;
            }

        }
        float N = l_boids.Count;
        pvj = pvj / (N - 1);

        return (pvj - bj.velocity) / catchUpVelocity; // Vitesse à laquelle il va rejoindre les autres
    }

    Vector3 away_from_place(Boid b)
    {
        return -repulsionForce * ((characterPos.position - b.getPosition()) / attractionForce);
    }

    void limit_velocity(Boid b)
    {
        float vlimNormalized = vlim / 1000;
        if (b.velocity.magnitude > vlimNormalized)
        {
            b.velocity = (b.velocity / b.velocity.magnitude) * vlimNormalized;
        }
    }

    Vector3 tend_to_place(Boid b)
    {

        int indMinDistance = 0;
        float minDistance = Vector3.Distance(attractions[0], b.getPosition());

        for (int i = 0; i < attractions.Count; i++)
        {
            if (Vector3.Distance(attractions[i], b.getPosition()) < minDistance)
            {
                indMinDistance = i;
                minDistance = Vector3.Distance(attractions[i], b.getPosition());
            }
        }


        return (attractions[indMinDistance] - b.getPosition()) / attractionForce;
    }




    Vector3 bound_position(Boid b)
    {
        Vector3 v = new Vector3();
        if (b.getPosition().x < minPos.x)
        {
            v.x = returnInRectangleVelocity;
        }
        else if (b.getPosition().x > maxPos.x)
        {
            v.x = -returnInRectangleVelocity;
        }

        if (b.getPosition().y < minPos.y)
        {
            v.y = returnInRectangleVelocity;
        }
        else if (b.getPosition().y > maxPos.y)
        {
            v.y = -returnInRectangleVelocity;
        }

        if (b.getPosition().z < minPos.z)
        {
            v.z = returnInRectangleVelocity;
        }
        else if (b.getPosition().z > maxPos.z)
        {
            v.z = -returnInRectangleVelocity;
        }
        return v;
    }



}
