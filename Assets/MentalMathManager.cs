using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MentalMathManager : GameManager
{

    const float DEFAULT_TIME_LIMIT = 60;
    const int DEFAULT_SCORE = 0;
    float ANSWER_ADDITION_TIME_LIMIT = 10;
    int MIN_NUMBER = 0;
    int MAX_NUBMER = 0;
    public TMP_InputField inputField;
    public TMP_Text scoreText;
    public TMP_Text operatorDisplayText;
    public TMP_Text highscoreText;
    public TMP_Text timerText;
    public TMP_Text titleText;
    public float currentAnswer;
    public string currentExpression;
    public Dictionary<Operator, bool> operators = new Dictionary<Operator, bool>();
    public void Start(){
        MentalModeData currentMentalModeData = UserDataManager.instance.currentMentalModeData;

        currentTimeLimit = currentMentalModeData.startTimeLimit;
        ANSWER_ADDITION_TIME_LIMIT = currentMentalModeData.correctAnswerIncrement;
        currentScore = DEFAULT_SCORE;
        MIN_NUMBER = currentMentalModeData.minNumber;
        MAX_NUBMER = currentMentalModeData.maxNumber;

        scoreText.text = currentScore.ToString();
        highscoreText.text = $"Highscore: {UserDataManager.getMentalModeHighscore(currentMentalModeData.modeID).ToString()}";
        titleText.text = currentMentalModeData.modeName;

        foreach(Operator op in currentMentalModeData.allowedOperators){
            operators.Add(op, true);
        }
        //If the operator isnt in the allowed operators, set it to false
        foreach(Operator op in System.Enum.GetValues(typeof(Operator))){
            if(!operators.ContainsKey(op)){
                operators.Add(op, false);
            }
        }

       UpdateQuestion();

    }
    public override void StartGame()
    {
        base.StartGame();
         currentTimeLimit = DEFAULT_TIME_LIMIT;
        currentScore = DEFAULT_SCORE;
        UpdateQuestion();
    }
    public override void EndGame()
    {

    }
    public void Update()
    {
        if(currentTimeLimit <= 0){
            EndGame();
            return;
        }
        currentTimeLimit -= Time.deltaTime;
        timerText.text = currentTimeLimit.ToString("F2");
    }
    public void UpdateQuestion()
    {
        string expression = "";
        string displayExpression = "";
        MathUtility.GenerateRandomExpression(2, operators, out expression, out displayExpression, MIN_NUMBER, MAX_NUBMER);
        operatorDisplayText.text = displayExpression;
        currentExpression = expression;
        inputField.text = "";
    }

    public void TryAnswer(string attemptedAnswer)
    {
        float correctAnswer;
        ExpressionEvaluator.Evaluate(currentExpression, out correctAnswer);
        if (float.TryParse(attemptedAnswer, out currentAnswer))
        {
            if (currentAnswer == correctAnswer)
            {
                currentScore++;
                scoreText.text = currentScore.ToString();
                currentTimeLimit += ANSWER_ADDITION_TIME_LIMIT;
                UpdateQuestion();
            }
            inputField.Select();
            inputField.ActivateInputField();
        }
    }
}
