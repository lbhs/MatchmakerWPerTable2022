using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoneWithThisGameScript : MonoBehaviour
{
    private int NumberOfQuestionsAnswered;
    private int SceneNumber;
    public GameObject AnswerManagementSystem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndTheGameInScene4()
    {
        NumberOfQuestionsAnswered = AnswerManagementSystem.GetComponent<AnswerKeyScript>().WhichSaltAreWeOn;  //WhichSaltAreWeOn increments by one each time a salt is "done"
        AnswerManagementSystem.GetComponent<GameOverRewardsScript>().MaxScore = NumberOfQuestionsAnswered * 2;
        
        if (NumberOfQuestionsAnswered > 4)
        {
            AnswerManagementSystem.GetComponent<GameOverRewardsScript>().Score = ScoringScript.PointsEarned;
            AnswerManagementSystem.GetComponent<GameOverRewardsScript>().ShowMedalWhenGameOver();
            //AnswerManagementSystem.GetComponent<GameOverRewardsScript>().StartGameOverProcess(ScoringScript.PointsEarned);
        }
        else
        {
            SceneNumber =  SceneManager.GetActiveScene().buildIndex;
            print("scene number = " + SceneNumber);
            SceneManager.LoadScene(SceneNumber);
        }
    }
}
