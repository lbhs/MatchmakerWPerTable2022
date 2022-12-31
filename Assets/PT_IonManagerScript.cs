using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PT_IonManagerScript : MonoBehaviour  //Attached to the PeriodicTableIonManager GameObject (only present in Periodic Table Scenes)

{
    public List<GameObject> PT_IonsInBondingArena;
    public List<GameObject> PT_ListOfIonsToInstantiate;  //This lists all the PREFAB ions in the periodic table display and allows a new one to be instantiated at the correct place
    //public int CheckSum;
    public GameObject MoleculeListKeeper;
    public GameObject PerTableAnswerManager;  
    public TMP_Text AnswerFeedbackTextBox;
    public Button ClearArenaButton;
    public Button SubmitAnswerButton;

    //public List<string> ListOfSaltNames;
    //public int SaltID;
    //public TMP_Text SaltNameDisplayTextbox;

    //public GameObject AnswerChoiceA;  //this is the answer display TMP Button--set to be inactive when a new salt is displayed
    //public GameObject AnswerChoiceB;
    //public GameObject AnswerChoiceC;
    

    // Start is called before the first frame update
    void Start()
    {
        MoleculeListKeeper = GameObject.Find("MoleculeListKeeper");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ClearTheBondingArena()
    {
        foreach (GameObject Ion in PT_IonsInBondingArena)   //MoleculeListKeeper.GetComponent<NetChargeCalculatorScript>().ListOfBondedIonsInThisMolecule)
        {
            Destroy(Ion);
        }

        //There is duplication below, but the two Lists are slightly different--MoleculeList only tracks BONDED ions, while PerTableIonManager collects unbonded ions as well
        PT_IonsInBondingArena.Clear();  //clear this list and the one kept by MoleculeListKeeper. . .
        MoleculeListKeeper.GetComponent<NetChargeCalculatorScript>().ListOfBondedIonsInThisMolecule.Clear();
        MoleculeListKeeper.GetComponent<NetChargeCalculatorScript>().netChargeOfMolecule = 0;
        SubmitAnswerButton.interactable = false;

        //Set all the variables back to their original states
        IonicBondingScript.BondHappened = false;
        NetChargeCalculatorScript.DraggingDisabled = false;

        AnswerFeedbackTextBox.text = null;

        GetComponent<InfoAboutIonsInTheArena>().AnionCharge = 0;
        GetComponent<InfoAboutIonsInTheArena>().CationCharge = 0;
        GetComponent<InfoAboutIonsInTheArena>().NumberOfAnions = 0;
        GetComponent<InfoAboutIonsInTheArena>().NumberOfCations = 0;
        GetComponent<InfoAboutIonsInTheArena>().CationID = 99;  //Li has IonID = 0, so don't want to use zero here. . .
        GetComponent<InfoAboutIonsInTheArena>().AnionID = 99;

        //ClearArena button is reactivated in the PT_DragIt script
        ClearArenaButton.interactable = false;

        PerTableAnswerManager.GetComponent<PeriodicTableAnswerScript>().IsVisualHintAppropriate();


    }

}







