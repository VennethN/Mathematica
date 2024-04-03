using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;

public class MainMenuManager : MonoBehaviour
{
        public static MainMenuManager instance;
        public Transform mentalHolder;
        public List<MentalMathButton> mentalMathButtons;

        public Database database{
            get{
                return DatabaseManager.getDatabase();
            
            }
        }
    // Start is called before the first frame update
        private void Awake()
    {
       instance = this;
    }
    async void Initiates()
    {
        await Task.Delay(500);
         for (int i = 0; i < mentalHolder.childCount; i++)
        {
            mentalHolder.GetChild(i).gameObject.SetActive(false);
            mentalMathButtons.Add(mentalHolder.GetChild(i).GetComponent<MentalMathButton>());
        }
        int mentalModeCount = 0;
        for (int i = 0; i < database.mentalModeDatas.Count; i++)
        {
             mentalMathButtons[mentalModeCount].updateButton(database.mentalModeDatas[i]);
                mentalHolder.GetChild(mentalModeCount).gameObject.SetActive(true);
                mentalModeCount++;
        }
    }
    private void Start()
    {
        Initiates();
    }

    public void StartMentalModeGame(MentalModeData mentalModeData)
    {
        UserDataManager.instance.currentMentalModeData = mentalModeData;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MentalMath");
    }

}
