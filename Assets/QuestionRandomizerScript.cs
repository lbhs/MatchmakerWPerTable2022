using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionRandomizerScript : MonoBehaviour  //attached to PerTableQuestionManager
{
    public int NumberOfQuestionsInBank;
    public int NumberOfQuestionPerGame;
    
    public List<int> RandomQuestionList;
    private int RandomQuestionNumber;
    private bool RejectThisNumber;
    private int i;
    public bool RandomizerActive;

    // Start is called before the first frame update
    void Start()  //Set up the RandomQuestionList
    {
        if (RandomizerActive)
        {
            //choose a random number between 0 and the NumberOfQuestionsInBank
            //Put this random question number into the RandomQuestionList
            //Choose another random number, check it against all the numbers already in the RandomQuestionList
            //if it is an unused number, put it in the List
            for (i = 0; i < NumberOfQuestionPerGame; i++)
            {
                RejectThisNumber = false;
                RandomQuestionNumber = Random.Range(0, NumberOfQuestionsInBank - 1);
                //print(RandomQuestionNumber);
                foreach (int J in RandomQuestionList)
                {
                    if (J == RandomQuestionNumber)
                    {
                        RejectThisNumber = true;
                    }
                }

                if (!RejectThisNumber)
                {
                    RandomQuestionList.Add(RandomQuestionNumber);
                }
                else
                {
                    i--;
                }
            }
        }

        else
        {
            for (i = 0; i < NumberOfQuestionPerGame; i++)
            {
                RandomQuestionList.Add(i);  //as i increments, each question number gets added to the list in order
            }
        }

        //So now the list is set up, and the PeriodicTableQuestionScript needs to read from the list
        GetComponent<PeriodicTableQuestionScript>().ShowTheFirstQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
