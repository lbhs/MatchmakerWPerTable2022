using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PeriodicTableScoreScript : MonoBehaviour  //attached to ScoreDisplay in PeriodicTable Game only--other games use ScoringScript
{
    public int PerTableScore;  //Score is 5 points if a student gets the answer right on the first try, then decreases by a point for each wrong answer or each hint taken
    public int NumberOfQuestionsPosed;  //this starts at zero, increments each time a new question is posed using the "AdvanceToNextQuestion" button
    public TMP_Text ScoreDisplay;


    // Start is called before the first frame update
    void Start()
    {
        NumberOfQuestionsPosed = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int Points)
    {
        PerTableScore += Points;
        ScoreDisplay.text = "Score = " + PerTableScore + "/" + NumberOfQuestionsPosed * 5;

    }
}
