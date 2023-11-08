using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimals : MonoBehaviour
{
    [SerializeField] Rigidbody prefab;
    [SerializeField] Rigidbody prefabVoisin;
    [SerializeField] float timer;
    [SerializeField] MeshRenderer meshGround;

    [SerializeField] float vitesse;

    Rigidbody instance;
    int nbAnimals;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPrefab", timer, timer);
        
    }

    void SpawnPrefab()
    {
        nbAnimals++;
        var position = new Vector3(Random.Range(meshGround.bounds.min.x, meshGround.bounds.max.x), 0, Random.Range(meshGround.bounds.center.z, meshGround.bounds.max.z));


        if (Random.Range(0, 2) > 0)
        {
            instance = Instantiate(prefab, position, Quaternion.identity);

        }
        else
        {
            instance = Instantiate(prefabVoisin, position, Quaternion.identity);
        }

        instance.gameObject.GetComponent<Deplacement>().min = meshGround.bounds.min.z;
        instance.gameObject.GetComponent<Deplacement>().max = meshGround.bounds.max.z;
        instance.gameObject.GetComponent<Deplacement>().vitesse = 10f;



    }

    public int getNbAnimals()
    {
        return nbAnimals;
    }

    private void Update()
    {
    }

    public void stopInvoke()
    {
        CancelInvoke("SpawnPrefab");
    }

}
