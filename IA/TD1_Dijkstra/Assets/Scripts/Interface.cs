using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class Interface : MonoBehaviour
{

    public void OnReloadButtonPressed()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadSceneAsync(scene.name);
    }

}
