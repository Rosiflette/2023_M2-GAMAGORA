using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GeneticAlgorithm : MonoBehaviour
{

    [SerializeField] private int numberCharacters;
    [SerializeField] private GameObject characterPrefab;

    private List<GameObject> listOfCharacters = new List<GameObject>();


    void Start()
    {
        InstantiateInitialCharacters();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GenerateNewCharacters();

        }
    }


    private void InstantiateInitialCharacters()
    {
        for (int i = 0; i < numberCharacters; i++)
        {
            float spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);
            float spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);

            Vector3 position = new Vector3(spawnX, spawnY, 0);
            GameObject currentCharacter = Instantiate(characterPrefab, position, Quaternion.identity, gameObject.transform);
            currentCharacter.GetComponent<DNA>().SetRandomColor(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
            listOfCharacters.Add(currentCharacter);
        }
    }


    private void GenerateNewCharacters()
    {
        List<GameObject> orderByFitnessList = FitnessOfCharacters();
        for (int i = 0; i < (int)numberCharacters / 2; i++)
        {
            orderByFitnessList[i].SetActive(false);
        }
        // listOfCharacters.Clear();
    }

    private List<GameObject> FitnessOfCharacters()
    {
        return listOfCharacters.OrderByDescending(o => o.GetComponent<DNA>().getRed()).Reverse().ToList();
    }

}
