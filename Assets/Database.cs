using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class Database
{
   public List<MentalModeData> mentalModeDatas;
}
[System.Serializable]
public class MentalModeData
{
    public string modeID;
    public string modeName;
    public List<Operator> allowedOperators;
    public int startTimeLimit;
    public int correctAnswerIncrement;
    public int wrongAnswerDecrement;
    public int minNumber;
    public int maxNumber;
}
