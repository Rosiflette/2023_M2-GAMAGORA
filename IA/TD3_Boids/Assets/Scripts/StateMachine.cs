using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{

    #region Singleton
    // La référence statique au singleton
    private static StateMachine _instance;
    public static StateMachine Instance
    {
        get
        {
            // Si l'instance n'existe pas, tentez de la trouver dans la scène
            if (_instance == null)
            {
                _instance = FindObjectOfType<StateMachine>();

                // Si l'instance n'a pas été trouvée dans la scène, créez-la
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("StateMachineSingleton");
                    _instance = singletonObject.AddComponent<StateMachine>();
                }
            }

            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
    #endregion

    public enum State{
        move,
        gameLose,
        runAway,
        dispatch
    }


    public State currentState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        
    }


}
