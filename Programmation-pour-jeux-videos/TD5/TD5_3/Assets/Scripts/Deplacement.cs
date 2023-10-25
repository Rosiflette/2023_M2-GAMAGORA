using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deplacement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private System.Random random;

    private Vector3 nextPosition;

    private float positionTolerance = 0.01f;
    private float rotationTolerance = 0.1f;

    private float max = 5f;
    private float min = 0f;

    

    private Quaternion targetRotation;

    // Start is called before the first frame update
    void Start()
    {
        random = new System.Random();

        nextPosition = gameObject.transform.position + new Vector3(0f, 0f, Random.Range(-1f, 1f));
        targetRotation = Quaternion.Euler(new Vector3(0f, Random.Range(-180f, 180f), 0f)); // Adjust the rotation as needed

    }

    // Update is called once per frame
    void Update()
    {

        

        if (Vector3.Distance(gameObject.transform.position, nextPosition) > positionTolerance)
        {
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, nextPosition, speed * Time.deltaTime);
        }
        else{
            nextPosition = gameObject.transform.position + new Vector3( Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f));
        }


        if (Quaternion.Angle(gameObject.transform.rotation, targetRotation) > rotationTolerance)
        {
            gameObject.transform.rotation = Quaternion.RotateTowards(gameObject.transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
        else{
            targetRotation = Quaternion.Euler(new Vector3(0f, Random.Range(-3f, 3f), 0f));         
        }


    }
}
