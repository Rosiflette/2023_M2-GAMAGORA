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

}
