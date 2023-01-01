using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltRandomizerScript : MonoBehaviour
{
    public int NumberOfQuestionsInBank;
    public int NumberOfQuestionPerGame;

    public List<int> ListOfRandomizedSalts;
    private int RandomQuestionNumber;
    private bool RejectThisNumber;
    private int i;
    
    // Start is called before the first frame update
    void Awake()  //Set up the RandomQuestionList
    {
            //choose a random number between 0 and the NumberOfQuestionsInBank
            //Put this random question number into the List
            //Choose another random number, check it against all the numbers already in the RandomQuestionList
            //if it is an unused number, put it in the List
            for (i = 0; i < NumberOfQuestionPerGame; i++)
            {
                RejectThisNumber = false;
                RandomQuestionNumber = Random.Range(1, NumberOfQuestionsInBank);
                //print(RandomQuestionNumber);
                foreach (int J in ListOfRandomizedSalts)
                {
                    if (J == RandomQuestionNumber)
                    {
                        RejectThisNumber = true;
                    }
                }

                if (!RejectThisNumber)
                {
                    ListOfRandomizedSalts.Add(RandomQuestionNumber);
                }
                else
                {
                    i--;
                }
            }


        //So now the list is set up, and the PeriodicTableQuestionScript needs to read from the list
        GetComponent<AnswerKeyScript>().IDNumberOfFirstSalt = ListOfRandomizedSalts[0]; 
        //GetComponent<PeriodicTableQuestionScript>().ShowTheFirstQuestion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
