using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
/*
[System.Serializable]
public class SaltIonOptions
{
    public List<GameObject> IonsInThisSalt = new List<GameObject>();  //sublist of individual ions for each choice from the master list.  Each salt has TWO ions to activate
}


public class DropdownSaltSelectorScript : MonoBehaviour
{
    public TMP_Dropdown TMPSaltSelector;
    public List<SaltIonOptions> ListOfSalts = new List<SaltIonOptions>();  //master list of possible salts
    public int SaltID;  //each salt on the dropdown has an integer to identify it!
    public List<GameObject> AllPossibleIons;  //A list of all the UI GameObjects from which Ions can be dragged--want to be able to turn these off when needed
    public List<GameObject> AnswerChoiceButtons;
    public TMP_Text AnswerChoiceFeedback;
    public GameObject ChosenCation;
    public GameObject ChosenAnion;




    /*
         1 = sodium chloride
         2 = sodium oxide
         3 = sodium phosphate
         4 = magnesium oxide
         5 = magnesium chloride
         6 = copper chloride
         7 = aluminum chloride
         8 = aluminum oxide
         9 = aluminum nitrate
         10 = copper nitrate
         11 = sodium sulfate
         12 = aluminum sulfate
         13 = magnesium sulfate
         14 = magnesium phosphate   
         */
/*
    public void SelectSaltFromDropdown()
    {

        if (TMPSaltSelector.value == 0)
        {
            return;
        }

        else
        {
            SaltID = TMPSaltSelector.value;  //this identifies the salt selected for Answer Choice processing
            ChosenCation = ListOfSalts[TMPSaltSelector.value].IonsInThisSalt[0];
            print("chosen cation =" + ChosenCation);
            ChosenAnion = ListOfSalts[TMPSaltSelector.value].IonsInThisSalt[1];
            print("chosen anion =" + ChosenAnion);



            foreach (var item in AnswerChoiceButtons)   //Reset the Answer Choice Buttons so that they are hidden and green
            {
                item.GetComponent<Image>().color = new Color32(48, 169, 06, 255);
                item.SetActive(false);
            }

            //disable all the ion choices, then activate the ONE that student has chosen.  OR use IonsToDisable. . .
            foreach (var item in AllPossibleIons)
            {
                item.SetActive(false);  //this deactivates the previously activated UI GameObjects from which Ions can be dragged  NEED TO CHANGE THIS SYSTEM TO REAL GAME OBJECTS.
            }


            foreach (var item in ListOfSalts[TMPSaltSelector.value].IonsInThisSalt)  //This activates the two ions that are currently "in play"
            {
                print(item);
                item.SetActive(true);
            }

            TMPSaltSelector.interactable = false;  //can't change the selected salt until this question is over

            AnswerChoiceFeedback.text = null;   //erases the "CORRECT" text in this text box


        }

    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}*/

