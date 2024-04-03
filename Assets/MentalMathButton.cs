using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MentalMathButton : MonoBehaviour
{
    public TMP_Text modeTitleText;
    public TMP_Text modeHighscoreText;
    public MentalModeData currentMentalModeData;


    public void updateButton(MentalModeData mentalModeData){
        currentMentalModeData = mentalModeData;
        modeTitleText.text = mentalModeData.modeName;
        modeHighscoreText.text = $"Highscore: {UserDataManager.getMentalModeHighscore(mentalModeData.modeID).ToString()}";
    }
    public void playMode(){
        MainMenuManager.instance.StartMentalModeGame(currentMentalModeData);
    }
}
