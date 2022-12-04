using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PeriodicTableQuestionScript : MonoBehaviour  //Attached to GameObject "PerTableQuestionManager"
{
    public List<string> ListOfQuestions;
    public int WhichQuestionAreWeOn;  //this identifies the question that will be asked
    public int QuestionCounter;  //this identifies the count of questions (0 to number of questions in round)

    public TMP_Text PT_QuestionPosed;
    public GameObject AdvanceToNextQuestionButton;                  //Button AdvanceToNextQuestionButton;
    public Button SubmitAnswerButton;
    public Button ClearArenaButton;
    public GameObject MoleculeListKeeper;
    public GameObject PerTableIonManager;
    public GameObject ScoreDisplay;
    public GameObject HintButton;  //need to reset FirstClickForThisHint when a new question appears
    

    // Start is called before the first frame update
    void Start()
    {
        
        
        MoleculeListKeeper = GameObject.Find("MoleculeListKeeper");
        AdvanceToNextQuestionButton.SetActive(false);             //interactable = false;
    }


    //Question 1 = Make the salt Potassium Fluoride
    //Q2 = Make a salt with formula X2Y1
    //Q3 = Make a salt that contains a divalent anion
    //Q4 = Make a salt with formula X1Z3


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowTheFirstQuestion()  //called from the QuestionRandomizerScript
    {
        QuestionCounter = 0;  //this will draw an integer from the RandomQuestionList generated in the QuestionRandomizerScript attached to PerTableQuestManager
        //WhichQuestionAreWeOn is an integer!  It identifies a particular question in the QuestionList that is input as a public variable
        //RandomQuestionList is a list of integers--not actual questions
        print("random set of questions generated using QuestionRandomizerScript");
        WhichQuestionAreWeOn = GetComponent<QuestionRandomizerScript>().RandomQuestionList[QuestionCounter];  // //WhichQuestionAreWeOn++;
        PT_QuestionPosed.text = ListOfQuestions[WhichQuestionAreWeOn];
    }

    public void AdvanceToNextQuestion()  //reads from the randomly generated list specified in QuestionRandomizerScript
    {
        if(QuestionCounter == GetComponent<QuestionRandomizerScript>().NumberOfQuestionPerGame - 1)
        {
            print("GAME OVER");
            PerTableIonManager.GetComponent<PT_IonManagerScript>().ClearTheBondingArena();  //CLEAR THE IONS
            GetComponent<GameOverScript>().ShowMedalWhenGameOver();            
            //CLEAR THE BONDING ARENA
            //DISPLAY A MEDAL AND EXPLANATORY TEXT            
        }

        else
        {
            //WhichQuestionAreWeOn is an integer!  It identifies a particular question in the QuestionList that is input as a public variable
            //RandomQuestionList is a random list of integers--not actual questions.  QuestionCounter will draw the random integers out one at a time

            QuestionCounter++;  //this moves to the next integer in the list of RandomQuestions
            WhichQuestionAreWeOn = GetComponent<QuestionRandomizerScript>().RandomQuestionList[QuestionCounter];   //WhichQuestionAreWeOn++;
            PT_QuestionPosed.text = ListOfQuestions[WhichQuestionAreWeOn];
            AdvanceToNextQuestionButton.SetActive(false);           //interactable = false;
            ScoreDisplay.GetComponent<PeriodicTableScoreScript>().NumberOfQuestionsPosed++;
            PerTableIonManager.GetComponent<PT_IonManagerScript>().ClearTheBondingArena();  //deletes the GameObjects and clears the PT_IonsInBondingArena List
            ClearArenaButton.interactable = false;  //reactivated in the PeriodicTableAnswerScript ActivateClearArenaButton(), which is called from PT_DragIt script
            HintButton.GetComponent<HintButtonScript>().FirstClickForThisHint = true;                                    
        }



    }

   
}
