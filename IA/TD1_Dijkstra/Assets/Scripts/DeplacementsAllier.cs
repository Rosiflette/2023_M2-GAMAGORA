using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeplacementsAllier : MonoBehaviour
{

    [SerializeField] private float speed;

    private float tileSpeed;
    // Start is called before the first frame update
    void Start()
    {
        speed = speed * Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 nextPos = MapManager.Instance.getNextPosAStar(gameObject);
        if (nextPos != Vector3.zero)
        {
            if ((int)gameObject.transform.position.x != (int)nextPos.x)
            {
                if ((int)gameObject.transform.position.x > (int)nextPos.x)
                {
                    gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
                }
                else
                {
                    gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
                }
            }
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPos, speed/MapManager.Instance.getCurrentTileSpeed());
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Fruit")
        {
            MapManager.Instance.IsFruitExisting(false);
            Destroy(other.gameObject);
        }
        if (other.tag == "Ennemi")
        {
            Debug.Log("You loose");
            Time.timeScale = 0f;

        }

    }


}
