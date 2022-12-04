using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnionTrigger1Script : MonoBehaviour
{
    public bool TriggerActivated;
    public float Y_OffsetThisTrigger;
    private bool FirstBondingTriggerRecorded;

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
        if(FirstBondingTriggerRecorded == false)
        {
            print("Trigger activated =" + gameObject);
            FirstBondingTriggerRecorded = true;
            print("Y_OffsetThisTrigger = " + Y_OffsetThisTrigger);
            GameObject ParentIon = transform.parent.gameObject;
            ParentIon.GetComponent<IonicBondingScript>().Y_OffsetOfThisIon = Y_OffsetThisTrigger;
            //gameObject.GetComponentInParent<IonicBondingScript>().Y_OffsetOfThisIon = -0.265f;  //should be -0.465
            print("Y-offset = " + ParentIon.GetComponent<IonicBondingScript>().Y_OffsetOfThisIon);
        }

        else
        {
            print("Second Trigger activated " + gameObject);
        }

        /*
        print("Trigger activated =" + gameObject);
        FirstBondingTriggerRecorded = true;
        print("Y_OffsetThisTrigger = " + Y_OffsetThisTrigger);
        GameObject ParentIon = transform.parent.gameObject;
        ParentIon.GetComponent<IonicBondingScript>().Y_OffsetOfThisIon = Y_OffsetThisTrigger;
        //gameObject.GetComponentInParent<IonicBondingScript>().Y_OffsetOfThisIon = -0.265f;  //should be -0.465
        print("Y-offset = " + ParentIon.GetComponent<IonicBondingScript>().Y_OffsetOfThisIon);*/
    }
}
