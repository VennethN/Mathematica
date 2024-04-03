using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{

    public static DatabaseManager instance;
    
    public Database database;

    void Awake()
    {
        //Initiates the singleton
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public static Database getDatabase()
    {
        return instance.database;
    }
}
