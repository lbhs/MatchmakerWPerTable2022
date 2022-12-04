using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//RelativeJoint version 
public class AnswerKeyScript : MonoBehaviour   //this script is attached to UI AnswerManagementSystem
{
    public string[] AnswerKey = new string[22];  //NEED TO SET THE DIMENSIONS OF THE ARRAY IN THE INSPECTOR!!!!
    public TMP_Text AnswerChoiceFeedback;
    public TMP_Dropdown SaltSelectorDropdown;
    public int PointsForThisQuestion = 2;
    private List<GameObject> IonsInCompletedSalt;
    private Rigidbody2D IonToMove;
    private int i; //for counting purposes
    public Vector3 TrophyCaseSlot1;
    public Vector3 TrophyCaseSlot2;
    public GameObject TrophyCaseImage;
    public List<Sprite> TrophyCaseImages;
    private List<GameObject> AllIonsInScene;

    public int NumberOfQuestionsInThisScene;
    public int IDNumberOfFirstSalt;
    public int WhichSaltAreWeOn;
    public Button AdvanceToNextSaltButton;


    // Start is called before the first frame update
    void Start()
    {
        WhichSaltAreWeOn = IDNumberOfFirstSalt;
        //answer choices are shown in AnswerManagementScript  Scene 1 = #1-6,  Scene 2 = #7-12,  Scene 3 = #13-18, Scene 4 = #19-24
        AnswerKey[1] = "A";
        AnswerKey[2] = "B";
        AnswerKey[3] = "B";
        AnswerKey[4] = "A";
        AnswerKey[5] = "B";
        AnswerKey[6] = "C";
        AnswerKey[7] = "B";
        AnswerKey[8] = "B";
        AnswerKey[9] = "C";
        AnswerKey[10] = "A";
        AnswerKey[11] = "C";
        AnswerKey[12] = "C";
        AnswerKey[13] = "A";
        AnswerKey[14] = "C";
        AnswerKey[15] = "A";
        AnswerKey[16] = "B";
        AnswerKey[17] = "B";
        AnswerKey[18] = "C";
        AnswerKey[19] = "C";
        AnswerKey[20] = "C";

        AnswerChoiceFeedback.text = null;

    }


    public void CheckAnswer(string ButtonChoice)
    {        
        if(ButtonChoice == AnswerKey[GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().SaltID])
        {
            //print("Correct");
            AnswerChoiceFeedback.color = Color.magenta;
            AnswerChoiceFeedback.text = "CORRECT!!!";
            GameObject.Find("CorrectAnswerSound").GetComponent<AudioSource>().Play();

            if (ButtonChoice == "A")   //Highlight the Correct Answer!
            {
                GameObject.Find("Answer Choice A").GetComponent<Image>().color = Color.magenta;
            }
            else if (ButtonChoice == "B")
            {
                GameObject.Find("Answer Choice B").GetComponent<Image>().color = Color.magenta;
            }
            else if (ButtonChoice == "C")
            {
                GameObject.Find("Answer Choice C").GetComponent<Image>().color = Color.magenta;
            }

            SaltSelectorDropdown.interactable = true;          
            ScoringScript.PointsEarned += PointsForThisQuestion;
            PointsForThisQuestion = 2;   //reset point value for the next question 

            DisableAnswerChoices();  //no spamming the correct answer choice!

            IonicBondingScript.BondHappened = false;  //reset this so that the next salt can instantiate first ion in the arena

            IonsInCompletedSalt = GameObject.Find("MoleculeListKeeper").GetComponent<NetChargeCalculatorScript>().ListOfBondedIonsInThisMolecule;

            //The two lines below will hide the draggable ions so that the user focuses only on the completed salt
            //print("Hiding draggable ions now");
            GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().HideTheDraggableIons();
            

            //DEACTIVATED AUG 31, 2022--DELETION OF IONS IS NOW DONE IN THE ShowTheNextSalt function, part of TMPDrowdownSaltSelectorScript
            ////The following code deletes all the "old" ions used to make the salt--once correct answer is chosen, need to clean the slate!
            //AllIonsInScene = GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().AllIonsInScene;

            //for (i = 0; i < AllIonsInScene.Count; i++)  //this part will delete all the ions in scene--bonded or unbonded!
            //{
            //    //print("ion[" + i + "] = " + AllIonsInScene[i]);
            //    Destroy(AllIonsInScene[i]);  
            //    //The ListOfBondedIonsInThisMolecule will be cleared when the user chooses a new salt from the TMP Dropdown Menu (TMPDrowdownSaltSelectorScript line 75)
            //}

            //DEACTIVATED AUGUST 31, 2022--NOW USING "ADVANCE TO NEXT SALT" BUTTON
            //GameObject.Find("TMP DropdownForSalts").GetComponent<TMP_Dropdown>().value = 0;  //this resets the dropdown menu to say "Choose a Salt"   

            // Instantiate(TrophyCaseImage, TrophyCaseSlot1, Quaternion.identity);  THIS IS DONE IN THE SlotController Script
            // Instantiate(TrophyCaseImages[GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().SaltID], TrophyCaseSlot2, Quaternion.identity);

            GameObject.Find("TrophyCase").GetComponent<SlotController>().PlaceImageInSlot(TrophyCaseImages[GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().SaltID]);
            AdvanceToNextSaltButton.interactable = true;

            //Keep track of which salt the user is on
            WhichSaltAreWeOn++;  //this variable is used in the SaltNameScript that is attached to the TMPDropdownSaltSelector GameObject
            if(WhichSaltAreWeOn == NumberOfQuestionsInThisScene+IDNumberOfFirstSalt)  //This means Game Over!  Start at #1, after 6 correct answers, WhichSaltAreWeOn will become #7
            {                
                AdvanceToNextSaltButton.interactable = false;
                GetComponent<GameOverRewardsScript>().StartGameOverProcess(ScoringScript.PointsEarned);  //send score to GameOver Script that will display medal and play song
            }
            

        }

        else
        {
            //print("wrong!");
            AnswerChoiceFeedback.color = Color.white;
            AnswerChoiceFeedback.text = "Incorrect--try again!";
            GameObject.Find("BondBrokenSound").GetComponent<AudioSource>().Play();
            if (ButtonChoice == "A")
            {
                GameObject.Find("Answer Choice A").GetComponent<Button>().interactable = false;
            }
            else if (ButtonChoice == "B")
            {
                GameObject.Find("Answer Choice B").GetComponent<Button>().interactable = false;
            }
            else if (ButtonChoice == "C")
            {
                GameObject.Find("Answer Choice C").GetComponent<Button>().interactable = false;
            }

            PointsForThisQuestion--;   //decrease point value for each incorrect answer
        }
    }

    private void DisableAnswerChoices()
    {
        GameObject.Find("Answer Choice A").GetComponent<Button>().interactable = false;
        GameObject.Find("Answer Choice B").GetComponent<Button>().interactable = false;
        GameObject.Find("Answer Choice C").GetComponent<Button>().interactable = false;
    }

    


    // Update is called once per frame
    void Update()
    {
        
    }


}
