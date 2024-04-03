using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
 public static class MathUtility{
    static Dictionary<Operator, string> operatorEnumToCharExpression =
        new Dictionary<Operator, string>() {
                {Operator.Addition, "+"},
                {Operator.Subtraction, "-"},
                {Operator.Multiplication, "*"},
                {Operator.Division, "/"}
            };
    static Dictionary<Operator, string> operatorEnumToCharDisplay =
        new Dictionary<Operator, string>() {
                {Operator.Addition, "+"},
                {Operator.Subtraction, "-"},
                {Operator.Multiplication, "*"},
                {Operator.Division, "÷"}

            };
        public static int RandomInt(int min, int max){
            return UnityEngine.Random.Range(min, max);
        }
        public static Operator GetRandomOperator(){
            return  (Operator)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Operator)).Length);
        }

        public static void GenerateRandomExpression(int operands, Dictionary<Operator,bool> allowedOperators, out string expression, out string displayExpression, int min = 0, int max = 100){
            expression = "";
            displayExpression = "";
            for (int i = 0; i < operands; i++)
            {
                int randomInt = RandomInt(min, max);
                expression += randomInt;
                displayExpression += $"{randomInt} ";
                if(i < operands - 1){
                    Operator randomOperator = GetRandomOperator();
                    while(!allowedOperators[randomOperator]){
                        randomOperator = GetRandomOperator();
                    }
                    expression += operatorEnumToCharExpression[randomOperator];
                    displayExpression += $"{operatorEnumToCharDisplay[randomOperator]} ";
                }
            }

        }
        
    }



public enum Operator
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}