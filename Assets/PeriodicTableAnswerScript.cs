using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PeriodicTableAnswerScript : MonoBehaviour  //Attached to PerTableAnswerManager
{
    //public List<int> AnswersToPeriodicTableQuestions;
    public GameObject MoleculeListKeeper;
    public GameObject PerTableIonManager;
    public GameObject PerTableQuestionManager;
    public GameObject HintButton;
    public int CheckSum;
    public int QuestionNumber;
    public AudioSource CorrectAnswerSound;
    public AudioSource WrongAnswerSound;
    public TMP_Text AnswerFeedbackTextbox;
    public GameObject AdvanceToNextQuestionButton;          //Button AdvanceToNextQuestionButton;
    public Button SubmitAnswerButton;
    public GameObject ClearArenaButton;
    public TMP_Text ScoreDisplay;
    public int PtsForThisQuestion;
    
   

    // Start is called before the first frame update
    void Start()
    {
        AdvanceToNextQuestionButton.SetActive(false);    //interactable = false;
        PtsForThisQuestion = 5;
        AnswerFeedbackTextbox.text = null;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*List of IonID values:  These are defined as a public array in the //PERIODICTABLEIONLISTKEEPER \\TMPDrowdownSelectorScript//  used when instantiating a new copy of the dragged ion!
    0 = Li+
    1 = Na+1
    2 = K+1
    3 = Rb+1
    4 = Mg+2
    5 = Ca+2
    6 = Sr+2 
    7 = Al+3
    8 = Ga+3
    9 = F-1
    10 = Cl-1
    11 = Br-1
    12 = I-1
    13 = O-2
    14 = S-2
    15 = N-3
    16 = P-3
    18 = Se-2

    */

    public void CheckAnswerForPeriodicTableQuestion()
    {
        print("Answer Check");
        QuestionNumber = PerTableQuestionManager.GetComponent<PeriodicTableQuestionScript>().WhichQuestionAreWeOn;
        //This is the place where answers for the PeriodicTable Game are processed.  Each ion has an ID (CationID or AnionID) used to check the student's answer
        //Strings can also be used??
        if(QuestionNumber == 0)  //Make the salt Potassium Fluoride
        {
            if(PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().CationID == 2 && PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().AnionID == 9)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 1)  //Make a salt with formula X2Y1
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfCations == 2 && PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfAnions == 1)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 2)  //Make a salt with a divalent anion
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().AnionCharge == -2)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 3)  //Make a salt with the formula X1Z3
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfCations == 1 && PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfAnions == 3)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 4)  //Make the salt Rubidium Sulfide  Rubidium ID = 3,   Sulfide ID = 14
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().CationID == 3 && PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().AnionID == 14)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 5)  //Make a salt with a Trivalent Cation
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().CationCharge == +3)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 6)  //Make a salt with the formula X2Z3
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfCations == 2 && PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfAnions == 3)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 7)  //Make the salt Strontium Iodide   Strontium ID = 6,  Iodide ID = 12
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().CationID == 6 && PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().AnionID == 12)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 8)  //Make a salt with a monovalent anion
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().AnionCharge == -1)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 9)  //Make a salt with the formula X3Z1
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfCations == 3 && PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfAnions == 1)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 10)  //Make the salt sodium nitride
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().CationID == 1 && PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().AnionID == 15)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 11)  //Make Calcium Phosphide  Calcium ID = 5, Phosphide ID = 16
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().CationID == 5 && PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().AnionID == 16)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

        if (QuestionNumber == 12)  //Not done yet
        {
            if (PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfCations == 1 && PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfAnions == 3)
            {
                CorrectAnswerResponse();
            }
            else
            {
                WrongAnswerResponse();
            }
        }

    }

    public void CorrectAnswerResponse()
    {        
        AnswerFeedbackTextbox.text = "Correct!";
        AnswerFeedbackTextbox.color = Color.green;
        CorrectAnswerSound.Play();
        AdvanceToNextQuestionButton.SetActive(true);    //interactable = true;
        SubmitAnswerButton.interactable = false;
        ClearArenaButton.GetComponent<Button>().interactable = false;
        ScoreDisplay.GetComponent<PeriodicTableScoreScript>().UpdateScore(PtsForThisQuestion);
        PtsForThisQuestion = 5;
        HintButton.GetComponent<HintButtonScript>().HideHintDisplayPanel();
        HintButton.GetComponent<HintButtonScript>().HideVisualHint();
    }

    public void WrongAnswerResponse()
    {
        print("incorrect");
        WrongAnswerSound.Play();
        AnswerFeedbackTextbox.text = "Wrong Answer.  Clear the Arena and Try Again";
        AnswerFeedbackTextbox.color = Color.yellow;
        SubmitAnswerButton.interactable = false;
        ClearArenaButton.SetActive(true);
        PtsForThisQuestion--;
        
    }

    public void ActivateClearArenaButton()
    {
        ClearArenaButton.GetComponent<Button>().interactable = true;
    }

    public void IsVisualHintAppropriate()
    {
        if (PtsForThisQuestion < 3)
        {
            print("time to show visual hint");
            HintButton.GetComponent<HintButtonScript>().ShowVisualHint();

        }
    
    }

}
