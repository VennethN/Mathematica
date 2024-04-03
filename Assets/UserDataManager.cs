using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;


public class UserDataManager : MonoBehaviour
{

    private string SAVE_FILE_PATH;
    public static UserDataManager instance;
    public MentalModeData currentMentalModeData;

    public Database database{
        get{
            return DatabaseManager.getDatabase();
        }
    }

    public UserData currentData;



    public static UserData getCurrentUserData()
    {
        return instance.currentData;
    }
    public static int getMentalModeHighscore(string modeID)
    {
        return instance.currentData.mentalModeHighscores[modeID];
    }

    private void Awake()
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
        SAVE_FILE_PATH = Application.persistentDataPath + "/MathematicaData.dat";
    }

    private void Start()
    {
        LoadData();
    }

    public void CheckModeHighscores()
    {
        List<MentalModeData> mentalModeDatabase = database.mentalModeDatas;
        Dictionary<string, int> mentalModeHighscores = currentData.mentalModeHighscores;
        if (mentalModeHighscores == null)
        {
            mentalModeHighscores = new Dictionary<string, int>();
        }
        
        foreach (MentalModeData mode in mentalModeDatabase)
        {
            if (!mentalModeHighscores.ContainsKey(mode.modeID))
            {
                 mentalModeHighscores.Add(mode.modeID, 0);
            }
        }
        foreach (var modeHighscore in mentalModeHighscores)
        {
            if (!mentalModeDatabase.Exists(mode => mode.modeID == modeHighscore.Key))
            {
                mentalModeHighscores.Remove(modeHighscore.Key);
            }
        }
    }

    public void SaveData()//Method to save player's data
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(SAVE_FILE_PATH);
        UserDataWrapper data = new UserDataWrapper();
        data.data = currentData;
        bf.Serialize(file, data);
        file.Close();
    }
    public void LoadData()//Method to load player's data
    {
        if (File.Exists(SAVE_FILE_PATH))
        {
            Debug.Log("DATA FOUND");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(SAVE_FILE_PATH, FileMode.Open);
            UserDataWrapper data = (UserDataWrapper)bf.Deserialize(file);
            currentData = data.data;
            file.Close();
        }
        else
        {
            currentData = new UserData();
            currentData.mentalModeHighscores = new Dictionary<string, int>();
        }
        CheckModeHighscores();
        // Save();

    }
}