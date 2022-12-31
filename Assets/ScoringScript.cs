using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringScript : MonoBehaviour  //Attached to ScoreDisplay
{
    public TMP_Text ScoreDisplay;
    public static int QuestionsAttempted;
    public static int PointsEarned;



    // Start is called before the first frame update
    void Start()
    {
        QuestionsAttempted = 0;
        PointsEarned = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreDisplay.text = ("Score = " + PointsEarned + "/" + QuestionsAttempted * 2);
    }
}
