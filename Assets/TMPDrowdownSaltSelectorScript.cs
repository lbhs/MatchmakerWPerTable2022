using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//THIS IS THE RelativeJoints VERSION!!!! 
[System.Serializable]
public class SaltIonOptions
{
    public List<GameObject> IonsInThisSalt = new List<GameObject>();  //sublist of individual ions for each choice from the master list.  Each salt has TWO ions to activate
    //public bool challenge;
    //These GameObjects are now rigidbody PreFab Ions, NOT UI elements!!
    /*TO ADD A NEW SALT:
        1. ADD THE COMPONENT IONS IN IN THIS PUBLIC LIST 
        2. PUT ITS NAME IN SaltNameScript 
        3. ADD A TROPHY CASE IMAGE TO THE AnswerKeyScript
        4. Add Answer Choices to AnswerManagementScript (3 answer choices for each salt)
        5. Put Correct Choice into AnswerKeyScript
    */
}


public class TMPDrowdownSaltSelectorScript : MonoBehaviour  //This script is attached to the UI GameObject  "TMP DropdownForSalts"
{
    public TMP_Dropdown TMPSaltSelector;
    public List<SaltIonOptions> ListOfSalts = new List<SaltIonOptions>();  //master list of possible salts
    public int SaltID;  //each salt on the dropdown has an integer to identify it  (starts at 1, bc 0 = "Choose a salt"!
    //public List<GameObject> AllPossibleIons;  //A list of all the UI GameObjects from which Ions can be dragged--want to be able to turn these off when needed
    public List<GameObject> AnswerChoiceButtons;  //3 answers for each salt choice
    public TMP_Text AnswerChoiceFeedback;  //the place where text messages are sent to the user
    public GameObject ChosenCation;  //Identity of the cation present in the chosen salt 
    public GameObject ChosenAnion;  //Identity of the anion present in the chosen salt
    //public static GameObject CationToDestroy;  //the "UI" Cation game object that sits in the original box--will be destroyed when a new salt is chosen.  This ion is identified in the DragIt script
    //public static GameObject AnionToDestroy; //the "UI" Anion game object that sits in the original box--will be destroyed when a new salt is chosen
    public GameObject BondingSpacePanel;  //NEW!!!
    public List<GameObject> AllIonsInScene;
    //public static int CationID;
    //public static int AnionID;
    private int i;
    public GameObject LastCationInstantiated;
    public GameObject LastAnionInstantiated;
    private Vector2 CationBoxCenterPoint = new Vector2(-5f, 4.2f);
    public TMP_Text SaltNameDisplay;


    //[SerializeField]
    //private bool competitionMode;

    [SerializeField]
    private AnswerManagementScript answerManagementScript;

    [SerializeField]
    private AnswerKeyScript answerKeyScript;

    public GameObject AnswerManagementSystem;


    /*
         1 = sodium chloride
         2 = sodium oxide
         3 = sodium phosphate
         4 = magnesium oxide
         5 = magnesium chloride
         6 = copper bromide
         7 = aluminum chloride
         8 = aluminum oxide (difficult)
         9 = aluminum nitrate (difficult)
         10 = copper nitrate
         11 = sodium sulfate
         12 = aluminum sulfate (difficult)
         13 = magnesium sulfate
         14 = magnesium phosphate
         15 = potassium bromide
         16 = potassium sulfate
         17 = ferric chloride
         18 = calcium phosphate (difficult)  
         19 = ferric sulfate (difficult)
         20 = 
         */



    public void ShowTheFirstSalt()
    {
        AllIonsInScene = new List<GameObject>();   //empty the list once a new salt is chosen
        print("Starting salt number = " + AnswerManagementSystem.GetComponent<AnswerKeyScript>().WhichSaltAreWeOn);  //AnswerKeyScript determines first salt to show
        SaltID = AnswerManagementSystem.GetComponent<AnswerKeyScript>().IDNumberOfFirstSalt;  //this identifies the salt selected (for determining Answer Choices for this salt)
        ChosenCation = ListOfSalts[SaltID].IonsInThisSalt[0];    //index 0 is always the cation
        print("chosen cation =" + ChosenCation);
        ChosenAnion = ListOfSalts[SaltID].IonsInThisSalt[1];  //index 1 is the anion
        print("chosen anion =" + ChosenAnion);
        NetChargeCalculatorScript.DraggingDisabled = false;


        //CationID = ChosenCation.GetComponent<DragIt>().IonID;
        //AnionID = ChosenAnion.GetComponent<DragIt>().IonID;

        GameObject.Find("MoleculeListKeeper").GetComponent<NetChargeCalculatorScript>().ListOfBondedIonsInThisMolecule = new List<GameObject>(); //starting a new molecule, so forget the old


        foreach (var item in AnswerChoiceButtons)   //Reset the Answer Choice Buttons so that they are hidden and green
        {
            item.GetComponent<Image>().color = new Color32(48, 169, 06, 255);  //Green color for buttons that are about to be used
            item.SetActive(false);  //hides the answer choice buttons until user has completed a salt in the bonding arena
        }

        //THIS IS WHERE THE NEW IONS ARE ADDED TO THE SCENE! 
        LastCationInstantiated = Instantiate(ChosenCation, new Vector3(-5f, 4.2f, 0), Quaternion.identity);
        AllIonsInScene.Add(LastCationInstantiated);  //these coordinates are the center of the Cation Display box 
        LastAnionInstantiated = Instantiate(ChosenAnion, new Vector3(5f, 4.2f, 0), Quaternion.identity);
        AllIonsInScene.Add(LastAnionInstantiated);

        AnswerChoiceFeedback.text = null;   //erases the "CORRECT" text in this text box
    }

    public void ShowTheNextSalt()  //called from the AdvanceToNextSalt button
    {
        for (i = 0; i < AllIonsInScene.Count; i++)  //this part will delete all the ions in scene--bonded or unbonded!
        {
            //print("ion[" + i + "] = " + AllIonsInScene[i]);
            Destroy(AllIonsInScene[i]);
            //The ListOfBondedIonsInThisMolecule will be cleared when the user chooses a new salt from the TMP Dropdown Menu (TMPDrowdownSaltSelectorScript line 75)
        }

        AllIonsInScene = new List<GameObject>();   //empty the list once a new salt is chosen
        SaltID = AnswerManagementSystem.GetComponent<AnswerKeyScript>().WhichSaltAreWeOn;  //this identifies the salt selected (for determining Answer Choices for this salt)
        ChosenCation = ListOfSalts[SaltID].IonsInThisSalt[0];    //index 0 is always the cation
        print("chosen cation =" + ChosenCation);
        ChosenAnion = ListOfSalts[SaltID].IonsInThisSalt[1];  //index 1 is the anion
        print("chosen anion =" + ChosenAnion);
        NetChargeCalculatorScript.DraggingDisabled = false;

        //DISABLED SEPT 1, 2022
        //CationID = ChosenCation.GetComponent<DragIt>().IonID;  //
        //AnionID = ChosenAnion.GetComponent<DragIt>().IonID;
       
        GameObject.Find("MoleculeListKeeper").GetComponent<NetChargeCalculatorScript>().ListOfBondedIonsInThisMolecule = new List<GameObject>(); //starting a new molecule, so forget the old
                

        foreach (var item in AnswerChoiceButtons)   //Reset the Answer Choice Buttons so that they are hidden and green
        {
            item.GetComponent<Image>().color = new Color32(48, 169, 06, 255);  //Green color for buttons that are about to be used
            item.SetActive(false);  //hides the answer choice buttons until user has completed a salt in the bonding arena
        }

        //THIS IS WHERE THE NEW IONS ARE ADDED TO THE SCENE!               
        AllIonsInScene.Add(Instantiate(ChosenCation, new Vector3(-5f, 4.2f, 0), Quaternion.identity));  //these coordinates are the center of the Cation Display box 
        AllIonsInScene.Add(Instantiate(ChosenAnion, new Vector3(5f, 4.2f, 0), Quaternion.identity));

        AnswerChoiceFeedback.text = null;   //erases the "CORRECT" text in this text box
    }

    public void InstantiateNewCation()
    {
        LastCationInstantiated = Instantiate(ChosenCation, new Vector2(-5f, 4.2f), Quaternion.identity);
        AllIonsInScene.Add(LastCationInstantiated);
    }

    public void InstantiateNewAnion()
    {
        LastAnionInstantiated = Instantiate(ChosenAnion, new Vector2(5f, 4.2f), Quaternion.identity);
        AllIonsInScene.Add(LastAnionInstantiated);
    }


    public void HideTheDraggableIons()
    {
        LastAnionInstantiated.SetActive(false);
        LastCationInstantiated.SetActive(false);
    }


    public void SelectSaltFromDropdown()
    {
        
        if (TMPSaltSelector.value == 0)  //value of 0 corresponds to "Choose a Salt"--salts are numbered 1-14, each with two ions to instantiate
        {
            return;
        }

        else
        {
            for (i = 0; i < AllIonsInScene.Count; i++)  //this part will delete all the ions in scene--bonded or unbonded!
            {
                //print("ion[" + i + "] = " + AllIonsInScene[i]);
                Destroy(AllIonsInScene[i]);
                //The ListOfBondedIonsInThisMolecule will be cleared when the user chooses a new salt from the TMP Dropdown Menu (TMPDrowdownSaltSelectorScript line 75)
            }

            AllIonsInScene = new List<GameObject>();   //empty the list once a new salt is chosen
            SaltID = TMPSaltSelector.value;  //this identifies the salt selected for Answer Choice processing
            ChosenCation = ListOfSalts[TMPSaltSelector.value].IonsInThisSalt[0];    //index 0 is always the cation
            print("chosen cation =" + ChosenCation);
            ChosenAnion = ListOfSalts[TMPSaltSelector.value].IonsInThisSalt[1];  //index 1 is the anion
            print("chosen anion =" + ChosenAnion);
            NetChargeCalculatorScript.DraggingDisabled = false;            


            GameObject.Find("MoleculeListKeeper").GetComponent<NetChargeCalculatorScript>().ListOfBondedIonsInThisMolecule = new List<GameObject>(); //starting a new molecule, so forget the old
            
            foreach (var item in AnswerChoiceButtons)   //Reset the Answer Choice Buttons so that they are hidden and green
            {
                item.GetComponent<Image>().color = new Color32(48, 169, 06, 255);
                item.SetActive(false);
            }          

            //THIS IS WHERE THE NEW IONS ARE ADDED TO THE SCENE!               
            AllIonsInScene.Add(Instantiate(ChosenCation, new Vector3(-5f, 4.2f, 0), Quaternion.identity));  //these coordinates are the center of the Cation Display box 
            AllIonsInScene.Add(Instantiate(ChosenAnion, new Vector3(5f, 4.2f, 0), Quaternion.identity));

            TMPSaltSelector.interactable = false;  //can't change the selected salt until this question is over

            AnswerChoiceFeedback.text = null;   //erases the "CORRECT" text in this text box
            SaltNameDisplay.text = "Salt Name: <br>" + GetComponent<SaltNameScript>().SaltNames[TMPSaltSelector.value];

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        //answerManagementScript.GenerateFormattedAnswerChoices();  //adds subscripts to the answer choices--now accomplished in AnswerManagementScript "Start" function

        //DEACTIVATED AUG 31, 2022--this was Sai's code used to generate random sets of 6-questions from the question bank
        //if (competitionMode)
        //{
        //    // Find all of the advanced problems in this game
        //    List<int> advancedProblemIndexes = new List<int>();

        //    for (int i = 0; i < ListOfSalts.Count; i++)
        //    {
        //        if (ListOfSalts[i].challenge)
        //        {
        //            advancedProblemIndexes.Add(i);
        //        }
        //    }

        //    // Generate the dropdown options in a new list
        //    List<TMP_Dropdown.OptionData> newOptions = new List<TMP_Dropdown.OptionData>();
        //    // First option just says "Choose a Salt"
        //    TMP_Dropdown.OptionData firstOption = new TMP_Dropdown.OptionData();
        //    firstOption.text = "Choose a Salt";
        //    newOptions.Add(firstOption);

        //    string[,] newAnswerChoices = new string[20, 3];
        //    string[] newAnswerKey = new string[20];

        //    // Generate the new set of salt options
        //    List<SaltIonOptions> newListOfSalts = new List<SaltIonOptions>();
        //    // Empty SaltIonOption corresponds with the empty dropdown option
        //    SaltIonOptions emptySaltIonOption = new SaltIonOptions();
        //    newListOfSalts.Add(emptySaltIonOption);

        //    // numSaltsToChoose - numSaltsToChooseAdvanced is the number of "easy" problems chosen by the system
        //    int numSaltsToChoose = 6;
        //    int numSaltsToChooseAdvanced = 2;

        //    int numSaltsChosen = 0;

        //    System.Random randObject = new System.Random();

        //    // "Easy" problems
        //    while (numSaltsChosen < (numSaltsToChoose - numSaltsToChooseAdvanced))
        //    {
        //        int randIndex = randObject.Next(TMPSaltSelector.options.Count);
        //        // We can't have the first option
        //        if (randIndex != 0)
        //        {
        //            if (!newListOfSalts.Contains(ListOfSalts[randIndex]) && !ListOfSalts[randIndex].challenge)
        //            {
        //                newListOfSalts.Add(ListOfSalts[randIndex]);
        //                TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
        //                option.text = TMPSaltSelector.options[randIndex].text;
        //                newOptions.Add(option);
        //                newAnswerChoices[numSaltsChosen + 1, 0] = answerManagementScript.AnswerChoices[randIndex, 0];
        //                newAnswerChoices[numSaltsChosen + 1, 1] = answerManagementScript.AnswerChoices[randIndex, 1];
        //                newAnswerChoices[numSaltsChosen + 1, 2] = answerManagementScript.AnswerChoices[randIndex, 2];
        //                newAnswerKey[numSaltsChosen + 1] = answerKeyScript.AnswerKey[randIndex];
        //                numSaltsChosen++;
        //            }
        //        }
        //    }

        //    // Difficult problems
        //    // If no difficult problems are chosen, this won't execute
        //    while (numSaltsChosen < numSaltsToChoose)
        //    {
        //        // Index in the list of indexes
        //        int randIndexInAdvancedList = randObject.Next(advancedProblemIndexes.Count);
        //        // Actual index
        //        int randIndex = advancedProblemIndexes[randIndexInAdvancedList];
        //        if (!newListOfSalts.Contains(ListOfSalts[randIndex]))
        //        {
        //            newListOfSalts.Add(ListOfSalts[randIndex]);
        //            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData();
        //            option.text = TMPSaltSelector.options[randIndex].text;
        //            newOptions.Add(option);
        //            newAnswerChoices[numSaltsChosen + 1, 0] = answerManagementScript.AnswerChoices[randIndex, 0];
        //            newAnswerChoices[numSaltsChosen + 1, 1] = answerManagementScript.AnswerChoices[randIndex, 1];
        //            newAnswerChoices[numSaltsChosen + 1, 2] = answerManagementScript.AnswerChoices[randIndex, 2];
        //            newAnswerKey[numSaltsChosen + 1] = answerKeyScript.AnswerKey[randIndex];
        //            numSaltsChosen++;
        //        }
        //    }

        //    ListOfSalts = newListOfSalts;
        //    TMPSaltSelector.options = newOptions;
        //    answerManagementScript.AnswerChoices = newAnswerChoices;
        //    answerKeyScript.AnswerKey = newAnswerKey;
        //    answerManagementScript.GenerateFormattedAnswerChoices();
        //}
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
