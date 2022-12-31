using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverScript : MonoBehaviour  //attached to PerTableQuestionManager 
{
    //USED IN PERIODIC TABLE SCENE ONLY!!!!
    public GameObject PerTableScoreDisplay;  //keeper of the score variable
    public GameObject CopperMedal;  //this is a UI Image centered on the screen
    public GameObject SilverMedal;
    public GameObject GoldMedal;
    public GameObject PlatinumMedal;
    private GameObject MedalOnDisplay;
    public int Score;
    public int MaxScore;
    public int PercentCorrect;

    //40 points possible for 8 questions
    public GameObject MedalExplanationText;  //Rock = 0-19 pts, Copper = 50-74%, Silver = 75-89%, Gold = 90-99%, Platinum = 100%  TMP_Text object displayed to the right of the medals
    public TMP_Text FinalScoreDisplay;

    public AudioSource CelebrationSound;  //Play this on a perfect score
    public AudioSource ApplauseSound;  //Play this if a Copper, Silver, or Gold Medal is achieved
    
    public GameObject BondingSpacePanel;  //will hide this when game is over--use the space to display a medal!
    public GameObject QuestionText;  //hide this when gameOver
    public GameObject AdvanceToNextQuestionButton;  //hide this when GameOver
    public GameObject ClearArenaButton;  //hide this when GameOver
    public GameObject SubmitAnswerButton;  //hide this when GameOver
    public GameObject FeedbackText;  //hide this when GameOver
    public GameObject HintButton;  //hide this when GameOver

    // Start is called before the first frame update
    void Start()
    {
        //MedalExplanationText.SetActive(false);
        FinalScoreDisplay.text = null;
        //MedalOnDisplay = CopperMedal;
        //MedalOnDisplay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowMedalWhenGameOver()  //called from AnswerKeyScript when final correct answer has been provided by user
    {
        //CALL THE CLEAR IONS FUNCTION
        Score = PerTableScoreDisplay.GetComponent<PeriodicTableScoreScript>().PerTableScore;
        BondingSpacePanel.SetActive(false);
        PercentCorrect = Mathf.RoundToInt(100 * Score / MaxScore);
        FinalScoreDisplay.text = "You earned " + Score + " Points <br>  (" + PercentCorrect + " %)";
        //MedalExplanationText.SetActive(true);
        print("Your Score = " + Score + " points");

        if (PercentCorrect < 50)
        {
            //ClangSound.Play();
        }
        else if (PercentCorrect < 75)
        {
            print("copper medal");
            MedalOnDisplay = CopperMedal;
            ApplauseSound.Play();
        }
        else if (PercentCorrect < 90)
        {
            print("silver medal");
            MedalOnDisplay = SilverMedal;
            ApplauseSound.Play();
        }
        else if (PercentCorrect < 100)
        {
            print("gold medal");
            MedalOnDisplay = GoldMedal;
            ApplauseSound.Play();
        }
        else
        {
            print("platium medal");
            MedalOnDisplay = PlatinumMedal;
            CelebrationSound.Play();
            ApplauseSound.Play();
        }

        MedalOnDisplay.SetActive(true);
        MedalExplanationText.SetActive(true);
        BondingSpacePanel.SetActive(false);  //will hide this when game is over--use the space to display a medal!
        QuestionText.SetActive(false);  //hide this when gameOver
        AdvanceToNextQuestionButton.SetActive(false);  //hide this when GameOver
        ClearArenaButton.SetActive(false);  //hide this when GameOver
        SubmitAnswerButton.SetActive(false);  //hide this when GameOver
        FeedbackText.SetActive(false);  //hide this when GameOver
        HintButton.SetActive(false);


    }   
}
