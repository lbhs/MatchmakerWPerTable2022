using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class AnswerKeyScene1 : MonoBehaviour  //attached to AnswerManagementSystem in Scene 1--Monatomic Ions
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


    // Start is called before the first frame update
    void Start()
    {
        //answer choices are shown in AnswerManagementScript
        AnswerKey[1] = "A";
        AnswerKey[2] = "B";
        AnswerKey[3] = "C";
        AnswerKey[4] = "A";
        AnswerKey[5] = "C";
        AnswerKey[6] = "C";

        AnswerChoiceFeedback.text = null;

    }

    public void CheckAnswer(string ButtonChoice)
    {


        if (ButtonChoice == AnswerKey[GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().SaltID])
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

            //The following code deletes all the "old" ions used to make the salt--once correct answer is chosen, need to clean the slate!
            AllIonsInScene = GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().AllIonsInScene;

            for (i = 0; i < AllIonsInScene.Count; i++)  //this part will delete all the ions in scene--bonded or unbonded!
            {
                //print("ion[" + i + "] = " + AllIonsInScene[i]);
                Destroy(AllIonsInScene[i]);
                //The ListOfBondedIonsInThisMolecule will be cleared when the user chooses a new salt from the TMP Dropdown Menu (TMPDrowdownSaltSelectorScript line 75)
            }



            GameObject.Find("TMP DropdownForSalts").GetComponent<TMP_Dropdown>().value = 0;  //this resets the dropdown menu to say "Choose a Salt"   
            //HIGHLIGHT THE "CHOOSE A SALT" OPTION SO THAT THE USER IS DRAWN TO USE THIS!



            // Instantiate(TrophyCaseImage, TrophyCaseSlot1, Quaternion.identity);  THIS IS DONE IN THE SlotController Script

            // Instantiate(TrophyCaseImages[GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().SaltID], TrophyCaseSlot2, Quaternion.identity);



            GameObject.Find("TrophyCase").GetComponent<SlotController>().PlaceImageInSlot(TrophyCaseImages[GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().SaltID]);







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


}
