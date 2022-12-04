using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonicBondingScript : MonoBehaviour
{
    //IONIC BONDING SCRIPT IS ATTACHED TO ALL ANIONS BUT NOT CATIONS!
        
    public float X_Offset;      //unique to each anion--horizontal distance from center point to bonding site
    public GameObject BondingPartner;       //the CationBondingTrigger to which this anion will bond
    public GameObject BondingPartnerParentIon;     //the rigidbody cation attached to the CationBondingTrigger
    public bool isBonded;
    public bool BondingEventInitiated;
    
    public float Y_OffsetOfThisIon;      //Currently, Y_Offset is initiated by each AnionBondingTrigger, then passed to IonicBondingScript--aligns the rigidbody Anion with the Cation
    public float FinalY_Offset;   //Takes into account the Y_OffsetOfThisIon and ??
    public int AnionValence;     //The original charge of the ion (absolute value thereof)
    public int ValenceRemaining;  //bonding sites that remain
    private int i;
   
    public GameObject ParentAtom;   //Not sure what this is for. . .
    //public List<GameObject> AnionTriggerList = new List<GameObject>();  //Used for polyvalent anions
    //public int SaltID;  //Chosen from the TMP DropdownForSalts--used to identify the ions in the salt and the answer choices that appear when bonding is complete
    public List<GameObject> ListOfBondedIonsInThisMolecule = new List<GameObject>();
    public Vector3 BondingArenaPosition;
    public static bool TimeToSpawn;
    public static bool BondHappened;






    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

    }

   
    public void UpdateVariablesAfterBondIsMade(GameObject BondingPartnerParentIon)  //called from the RelativeJointScript after physical joints have been added to the bonding partners
    {
        //print("UpdateVariables");

        if(BondHappened == false)  //want only one "bonding event" to register when multivalent ions bond together
        {
            TimeToSpawn = true; //allows replenishing of the cation and anion in the original UI boxes
            BondHappened = true;  //allows for only one bonding event to update variables--each trigger will make a relative joint, however
            BondingEventInitiated = false;    //when "false", allows a new Bonding event to begin in future--needed for polyvalent ions

            AnionTriggerScript.FirstBondingTriggerRecorded = false;   //Once bonding event is complete, any unused AnionBondingTriggers are "open for business"

            GameObject.Find("MoleculeListKeeper").GetComponent<NetChargeCalculatorScript>().UpdateTheMoleculeList(gameObject, BondingPartnerParentIon);  //this keeps track of the ions that have bonded to make a "molecule"
            isBonded = true;  //used to identify that a bond has been made on this dragging event
            GameObject.Find("BondMadeSound").GetComponent<AudioSource>().Play();  //this makes the sound

            //print("Net Charge = " + GameObject.Find("MoleculeListKeeper").GetComponent<NetChargeCalculatorScript>().netChargeOfMolecule);

            //In Periodic Table Game, CheckSum is used to determine whether the user has created the correct salt.  Checksum is calculated in NetChargeCalculatorScript 

            if (GameObject.Find("MoleculeListKeeper").GetComponent<NetChargeCalculatorScript>().netChargeOfMolecule != 0)  //will be 0 if molecule is complete
            {
                NetChargeCalculatorScript.DraggingDisabled = false;    //if netCharge is not zero, more molecular assembly needs to be done, so enable dragging of ions 
                print("IonicBondingScript makes DraggingDisabled = false");  //needed to check whether netCharge = 0  
            }
            else
            {
                NetChargeCalculatorScript.DraggingDisabled = true;
            }
        }
        

    }




}

