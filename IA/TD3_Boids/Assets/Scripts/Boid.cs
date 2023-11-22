using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour
{

    public Vector3 velocity = new Vector3();

    public StateMachine.State currentState;

    public Boid(Vector3 _velocity)
    {
        currentState = StateMachine.State.move;
        velocity = _velocity;
    }

    public Vector3 getPosition(){
        return gameObject.transform.position;
    }

    public void setPosition(Vector3 newPos){
        gameObject.transform.position = newPos;
    }


    public Vector3 rule1(List<Boid> listBoid)
    {
        float N = listBoid.Count;
        Vector3 pcj = new Vector3();
        if (N < 2)
        {
            return pcj;
        }

        foreach (Boid b in listBoid)
        {
            if (b != this)
            {
                pcj = pcj + b.getPosition();
            }
        }
        pcj = pcj / (N - 1);


        return (pcj - this.getPosition()) / 1000;
    }

    public Vector3 rule2(List<Boid> listBoid, float spaceBetween)
    {
        Vector3 c = Vector3.zero;

        foreach (Boid b in listBoid)
        {
            if (b != this)
            {

                if ((b.getPosition() - this.getPosition()).magnitude < spaceBetween)
                {
                    c = c - (b.getPosition() - this.getPosition())*2;
                }

            }
        }

        return c;

    }

    public Vector3 rule3(List<Boid> listBoid, float catchUpVelocity)
    {
        Vector3 pvj = new Vector3();

        float N = listBoid.Count;
        Vector3 pcj = new Vector3();
        if (N < 2)
        {
            return pcj;
        }

        foreach (Boid b in listBoid)
        {
            if (b != this)
            {
                pvj = pvj + b.velocity;
            }

        }
        pvj = pvj / (N - 1);

        return (pvj - this.velocity) / catchUpVelocity; // Vitesse à laquelle il va rejoindre les autres
    }

    public Vector3 away_from_place(float repulsionForce, float attractionForce, Vector3 characterPos)
    {
        return -repulsionForce * ((characterPos - this.getPosition()) / attractionForce);
    }

    public void limit_velocity(float vlim)
    {
        float vlimNormalized = vlim / 1000;
        if (this.velocity.magnitude > vlimNormalized)
        {
            this.velocity = (this.velocity / this.velocity.magnitude) * vlimNormalized;
        }
    }

    public Vector3 tend_to_place(Vector3 nearestAttraction, float attractionForce)
    {
        return (nearestAttraction - this.getPosition()) / attractionForce;
    }

    public Vector3 bound_position(Vector3 minPos, Vector3 maxPos, float returnInRectangleVelocity)
    {
        Vector3 v = new Vector3();
        if (this.getPosition().x < minPos.x)
        {
            v.x = returnInRectangleVelocity;
        }
        else if (this.getPosition().x > maxPos.x)
        {
            v.x = -returnInRectangleVelocity;
        }

        if (this.getPosition().y < minPos.y)
        {
            v.y = returnInRectangleVelocity;
        }
        else if (this.getPosition().y > maxPos.y)
        {
            v.y = -returnInRectangleVelocity;
        }

        if (this.getPosition().z < minPos.z)
        {
            v.z = returnInRectangleVelocity;
        }
        else if (this.getPosition().z > maxPos.z)
        {
            v.z = -returnInRectangleVelocity;
        }
        return v;
    }

}
