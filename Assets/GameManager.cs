using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public int currentScore;
    public float currentTimeLimit;

    void Awake()
    {
        //Initiates the singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public virtual void StartGame()
    {

    }
    public virtual void EndGame()
    {

    }
}
