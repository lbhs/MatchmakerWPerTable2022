using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnionTriggerScript : MonoBehaviour
{
    public bool TriggerActivated;
    public float Y_OffsetThisTrigger;
    public static bool FirstBondingTriggerRecorded;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //DEACTIVATED AUGUST 29, 2022
        //if (FirstBondingTriggerRecorded == false)
        //{
        //    print("Trigger activated =" + gameObject);
        //    TriggerActivated = true;         //once Activated, should decrease Valence by 1 AND deactivate the collider so that glitchy things don't happen
        //    FirstBondingTriggerRecorded = true;   //important when a polyvalent anion is bonding--only want one Bonding Trigger to set the position of the Rigidbody Ion
        //    print("Y_OffsetThisTrigger = " + Y_OffsetThisTrigger);  //this sets the Y-coordinate of where the Rigidbody Ion will end up
        //    GameObject ParentIon = transform.parent.gameObject;        //ParentIon is the Rigidbody ion
        //    ParentIon.GetComponent<IonicBondingScript>().Y_OffsetOfThisIon = Y_OffsetThisTrigger;  //transfer the Y-offset to the Parent Rigidbody Ion
            
        //    print("Y-offset = " + ParentIon.GetComponent<IonicBondingScript>().Y_OffsetOfThisIon);
        //    print("Trigger Status " + TriggerActivated);
        //}

        //else   //THIS MAY BE USELESS NOW THAT NETCHARGE IS THE MARKER FOR A COMPLETE SALT MOLECULE
        //{
        //    print("Second Trigger activated =" + transform);
        //    TriggerActivated = true;  //once Activated, should decrease Valence by 1 and deactivate the collider. . .
        //}

        
    }


}
