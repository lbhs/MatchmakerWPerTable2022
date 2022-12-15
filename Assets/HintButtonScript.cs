using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HintButtonScript : MonoBehaviour
{
    public GameObject HintDisplayPanel;
    public GameObject VisualHintDisplayPanel;  //a bigger display panel for the visual hints

    public TMP_Text HintDisplayText;
    
    public List<string> ListOfHints;   //each question will have a hint: a guiding explanation, 
    public List<GameObject> ListOfVisualAnswers; //each is a visual hint showing an actual answer(automatically triggered if the user has only 2 pts left to earn on that question)
    public GameObject PerTableQuestionManager;  //keeper of the key variable WhichQuestionAreWeOn
    public GameObject PerTableAnswerManager;  //keeper of the PtsForThisQuestion variable -- decrement by 1 when hint is requested
    public bool FirstClickForThisHint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowHintDisplayPanel()
    {
        HintDisplayPanel.SetActive(true);
        HintDisplayText.text = ListOfHints[PerTableQuestionManager.GetComponent<PeriodicTableQuestionScript>().WhichQuestionAreWeOn];
        if (FirstClickForThisHint)
        {
            PerTableAnswerManager.GetComponent<PeriodicTableAnswerScript>().PtsForThisQuestion--;
            FirstClickForThisHint = false;
        }
        
    }

    public void HideHintDisplayPanel()
    {
        HintDisplayPanel.SetActive(false);
        ListOfVisualAnswers[PerTableQuestionManager.GetComponent<PeriodicTableQuestionScript>().WhichQuestionAreWeOn].SetActive(false);
    }

    public void ShowVisualHint()
    {
        VisualHintDisplayPanel.SetActive(true);
        HintDisplayPanel.SetActive(false);
        //HintDisplayText.text = "Try this:";
        ListOfVisualAnswers[PerTableQuestionManager.GetComponent<PeriodicTableQuestionScript>().WhichQuestionAreWeOn].SetActive(true);
    }

    public void HideVisualHint()
    {
        VisualHintDisplayPanel.SetActive(false);
        ListOfVisualAnswers[PerTableQuestionManager.GetComponent<PeriodicTableQuestionScript>().WhichQuestionAreWeOn].SetActive(false);
    }


}
