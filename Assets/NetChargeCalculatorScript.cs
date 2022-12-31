using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetChargeCalculatorScript : MonoBehaviour
{
    //This Script is Attached to the GameObject MoleculeListKeeper

    public List<GameObject> ListOfBondedIonsInThisMolecule = new List<GameObject>();  //This is the list of ions that have been bonded together for this salt
    private int i;  //for index
    public int netChargeOfMolecule;
    public int SaltID;  //identified in the TMPDrowdownSaltSelectorScript--duplicated here for convenience
    public bool ThisIsThePeriodicTableScene;  
    public static bool DraggingDisabled;  //this needs to be in a UNIQUE location. . .  Put it on MoleculeListKeeper?
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void UpdateTheMoleculeList(GameObject Anion, GameObject Cation)  //This function is called from IonicBondingScript (line 68)
                                                                            //NEED TO CLEAR THE LIST WHEN THE MOLECULE IS COMPLETE!!!
    {
        //print("UpdateTheMoleculeList");

        netChargeOfMolecule = 0;  //reset this variable prior to counting valence each time a bond is made

        if (ListOfBondedIonsInThisMolecule.Contains(Anion))  // the GameObject MoleculeListKeeper knows which ions have been bonded together
        {
            //do nothing
        }
        else
        {
            ListOfBondedIonsInThisMolecule.Add(Anion);
        }

        if (ListOfBondedIonsInThisMolecule.Contains(Cation))
        {
            //do nothing
        }
        else
        {
            ListOfBondedIonsInThisMolecule.Add(Cation);
        }

        CalculateNetCharge();
    }

    public void CalculateNetCharge()
    {
        for (i = 0; i < ListOfBondedIonsInThisMolecule.Count; i++)
        {
            //print(ListOfBondedIonsInThisMolecule[i]);
            netChargeOfMolecule += ListOfBondedIonsInThisMolecule[i].GetComponent<ValenceScript>().ionCharge;
        }

        //print("Net charge = " + netChargeOfMolecule);

        if (netChargeOfMolecule == 0)
        {
            GameObject.Find("MoleculeCompleteSound").GetComponent<AudioSource>().Play();

            if (GameObject.Find("PerTableAnswerManager"))
            {

                //AnswerCheck is called from PT_DragIt script. Need to wait for ions to be "tallied", which occurs OnMouseUp.
                //GameObject.Find("PerTableAnswerManager").GetComponent<PeriodicTableAnswerScript>().CheckAnswerForPeriodicTableQuestion();
            }

            else
            {
                SaltID = GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().SaltID;
                GameObject.Find("AnswerManagementSystem").GetComponent<AnswerManagementScript>().DisplayAnswerChoices(SaltID);  //displays the three multiple choice answers for this salt
            }

            //MOVED THIS FUNCTION TO THE ANSWERKEYSCRIPT 
            //if (!GameObject.Find("PerTableQuestionManager"))  //Periodic Table scene doesn't use this 2-point system
            //{
            //    ScoringScript.QuestionsAttempted++;  //each question has 2 possible points 
            //}
                    

            DraggingDisabled = true;
            print("DraggingDisabled = true");

        }
    }    
}
