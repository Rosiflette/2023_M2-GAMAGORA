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

        // neighbors
        List<Boid> neighbors = new List<Boid>();
        foreach (Boid boid in l_boids)
        {
            if (Vector3.Distance(boid.getPosition(), b.getPosition()) < 0.1)
            {
                neighbors.Add(boid);
            }
        }

        // Nearest flower
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

        v1 = b.rule1(neighbors);
        v1 += b.rule2(neighbors, spaceBetween);
        v1 += b.rule3(neighbors, catchUpVelocity);
        v1 += b.tend_to_place(attractions[indMinDistance], attractionForce);
        //v1 += b.bound_position(minPos, maxPos, returnInRectangleVelocity);
        if (isFlyAway)
        {
            v1 += b.away_from_place(repulsionForce, attractionForce, characterPos.position);
        }

        b.velocity = b.velocity + v1;

        b.limit_velocity(vlim);

        b.setPosition(b.getPosition() + b.velocity*30 * Time.deltaTime);


    }





}
