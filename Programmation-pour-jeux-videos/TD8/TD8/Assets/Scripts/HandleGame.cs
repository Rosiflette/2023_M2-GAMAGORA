using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGame : MonoBehaviour
{
    [SerializeField] private GameObject barrier;

    private GameObject character;

    void Start()
    {
        character = GameObject.Find("Character");
        InvokeRepeating("AddBarrier", 2.0f, 5f);
    }

    void Update()
    {
        if (character.GetComponent<ControlCharacter>().IsGameOver())
        {
            CancelInvoke("AddBarrier");

        }
    }

    void AddBarrier()
    {
        Instantiate(barrier, new Vector3(30f, 0, 0), Quaternion.identity);

    }
}
