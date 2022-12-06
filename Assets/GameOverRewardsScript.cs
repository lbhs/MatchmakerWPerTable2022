using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverRewardsScript : MonoBehaviour  //Attached to the AnswerManagementSystem GameObject
{
    private List<GameObject> AllIonsInScene;
    private int i;

    public GameObject CopperMedal;  //this is a UI Image centered on the screen
    public GameObject SilverMedal;
    public GameObject GoldMedal;
    public GameObject PlatinumMedal;
    private GameObject MedalOnDisplay;
    public int Score;
    public int MaxScore;
    private int PercentCorrect;

    public GameObject MedalExplanationText;  //Rock = 0-2 pts, Copper = 3-6 pts, Silver = 7-9 pts, Gold = 10-11 pts, Platinum = 12 pts  TMP_Text object displayed to the right of the medals
    public TMP_Text FinalScoreDisplay;

    public AudioSource CelebrationSound;  //Play this on a perfect score
    public AudioSource ApplauseSound;  //Play this if Gold Medal is achieved
    public AudioSource ToasterOvenDingSound; //Play this on Copper or Silver Medal
    public AudioSource ClangSound; //Play this on Less than 3 points
    public AudioSource CountUpSound; //Play this during prelude to medal display

    public GameObject BondingSpacePanel;  //will hide this when game is over--use the space to display a medal!
    public GameObject AnswerChoiceA;  //will hide this when game is over
    public GameObject AnswerChoiceB;  //will hide this when game is over
    public GameObject AnswerChoiceC;
    public GameObject AnswerChoiceText;  //will hide this when game is over
    public GameObject SaltNameText;  //will hide this when game is over

    //public GameObject AnswerManagementSystem;  //keeper of the variable NumberOfQuestions in this game  ALREADY THE CURRENT GAMEOBJECT!!!


    // Start is called before the first frame update
    void Start()
    {
        MedalExplanationText.SetActive(false);
        FinalScoreDisplay.text = null;
        MaxScore = GetComponent<AnswerKeyScript>().NumberOfQuestionsInThisScene * 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameOverProcess(int score)  //called from AnswerKeyScript line 119
        //first give user time to see their correct response to the final question.  Then start medal display
    {
        Score = score;
        StartCoroutine(PreludeToMedalDisplay());
    }

    public void ShowMedalWhenGameOver()  //called from AnswerKeyScript when final correct answer has been provided by user
    {
        AllIonsInScene = GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().AllIonsInScene;
        PercentCorrect = 100 * Score / MaxScore;

        for (i = 0; i < AllIonsInScene.Count; i++)  //this part will delete all the ions in scene--bonded or unbonded!
        {
            Destroy(AllIonsInScene[i]);
        }

        FinalScoreDisplay.text = "You earned " + Score + " Points, <br>" + PercentCorrect + " %";
        MedalExplanationText.SetActive(true);
        //print("Your Score = " + Score + " points");

        if (PercentCorrect < 50)
        {
            ClangSound.Play();
        }
        else if(PercentCorrect < 70)
        {
            
            MedalOnDisplay = CopperMedal;
            ToasterOvenDingSound.Play();
        }
        else if (PercentCorrect < 83)
        {
            MedalOnDisplay = SilverMedal;
            ToasterOvenDingSound.Play();
        }
        else if (PercentCorrect < 100)
        {
            MedalOnDisplay = GoldMedal;
            ApplauseSound.Play();
        }
        else 
        {
            MedalOnDisplay = PlatinumMedal;
            CelebrationSound.Play();
            ApplauseSound.Play();
        }

        MedalOnDisplay.SetActive(true);
        BondingSpacePanel.SetActive(false);
        AnswerChoiceA.SetActive(false);
        AnswerChoiceB.SetActive(false);
        AnswerChoiceC.SetActive(false);
        AnswerChoiceText.SetActive(false);
        SaltNameText.SetActive(false);
    }

    public IEnumerator PreludeToMedalDisplay()
    {
        yield return new WaitForSeconds(1f);
        CountUpSound.Play();
        yield return new WaitForSeconds(4f);
        CountUpSound.Stop();        
        ShowMedalWhenGameOver();
    }
}
