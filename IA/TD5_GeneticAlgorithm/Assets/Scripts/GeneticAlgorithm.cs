using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{

    [SerializeField] private int numberCharacters;
    [SerializeField] private GameObject characterPrefab;

    private List<GameObject> listOfCharacters;


    void Start()
    {
        InstantiateInitialCharacters();
    }


    private void InstantiateInitialCharacters()
    {
        for(int i = 0; i < numberCharacters; i++)
        {

            Vector3 position = new Vector3(
                Random.Range(0, gameObject.GetComponent<RectTransform>().rect.width),
                Random.Range(0, gameObject.GetComponent<RectTransform>().rect.height), 0
            );
            
            listOfCharacters.Add(Instantiate(characterPrefab, position,  Quaternion.identity));
        }
    }

    private void GenerateNewCharacters(){
        List<GameObject> orderByFitnessList = FitnessOfCharacters();
        listOfCharacters.Clear();

    }

    private List<GameObject> FitnessOfCharacters(){
        return listOfCharacters.OrderByDescending(o => o.GetComponent<DNA>().red).ToList();

    }

    void Update()
    {
        
    }
}
