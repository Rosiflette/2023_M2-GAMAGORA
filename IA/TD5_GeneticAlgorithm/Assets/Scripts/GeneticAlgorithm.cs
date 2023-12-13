using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{

    [SerializeField] private int numberCharacters;
    [SerializeField] private GameObject characterPrefab;
    [SerializeField] private Canvas canva;


    void Start()
    {
        
    }


    void InitializeCharacters()
    {
        for(int i = 0; i < numberCharacters; i++)
        {
            Vector2 position = new Vector2(new Random.Range(canva, canva.pixelRect.y), new Random.Range());
            Instantiate(characterPrefab, );
        }
    }

    void Update()
    {
        
    }
}
