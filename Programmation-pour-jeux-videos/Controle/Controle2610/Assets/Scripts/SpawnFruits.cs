using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruits : MonoBehaviour
{
    [SerializeField] Rigidbody prefab;
    [SerializeField] Rigidbody prefabVoisin;
    [SerializeField] float timer;
    [SerializeField] MeshRenderer meshGround;


    Rigidbody instance;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPrefab", timer, timer);
        
    }

    void SpawnPrefab()
    {

        var position = new Vector3(Random.Range(meshGround.bounds.min.x, meshGround.bounds.max.x), 1.5f, Random.Range(meshGround.bounds.min.z, meshGround.bounds.max.z));


        if (Random.Range(0, 2) > 0)
        {
            instance = Instantiate(prefab, position, Quaternion.identity);
        }
        else
        {
            instance = Instantiate(prefabVoisin, position, Quaternion.identity);
        }

    }

    private void Update()
    {
    }

    public void stopInvoke()
    {
        CancelInvoke("SpawnPrefab");
    }

}
