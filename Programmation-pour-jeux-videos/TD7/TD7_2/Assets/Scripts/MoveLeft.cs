using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    [SerializeField] private float speed;
    private GameObject character;
    private bool isObstacle = false;

    private GameObject ground;

    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character");
        if(gameObject.tag == "Obstacle"){
            isObstacle = true;
        }

        ground = GameObject.Find("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if (!character.GetComponent<ControlCharacter>().IsGameOver())
        {
            gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0, 0);

        }
        if(isObstacle && ( gameObject.transform.position.x < -ground.GetComponent<BoxCollider>().size.x)){
            Destroy(gameObject);
        }
    }
}
