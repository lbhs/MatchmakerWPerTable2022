using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_RelativeJointScript : MonoBehaviour  //this script is attached to AnionBondingTriggers of Periodic Table ions--different scaling
{
    RelativeJoint2D joint;

    public GameObject ParentIon;  //The ParentIon is the Rigidbody Anion to which the Anion Trigger is a child

    public GameObject BondingPartner;       //the CationBondingTrigger to which this anion will bond
    public GameObject BondingPartnerParentIon;     //the rigidbody cation attached to the CationBondingTrigger
                                                   
    public float CationTriggerOffset_Y;
    public float CationTriggerOffset_X;

    public float Y_OffsetOfThisAnionTrigger;      //Currently, Y_Offset is initiated by each AnionBondingTrigger, then passed to IonicBondingScript--aligns the rigidbody Anion with the Cation
    public float FinalY_Offset;   //Takes into account the Y_OffsetOfThisIon and Y_Offset of CationTrigger

    public float X_OffsetOfThisAnion;      //unique to each anion--horizontal distance from center point to bonding site MULTIPLIED BY THE SCALE OF THE PARENT ION!!!!  (e.g. for Br-1, 2.87 rel pos of anion trigger x 0.3 scale = 0.861 offset)
    public float FinalX_Offset;   //Takes into account the X_OffsetOfThisIon and X_Offset of CationTrigger

    
    public AudioSource VictorySound;

    public Vector2 BondingArenaPosition;
    public GameObject PerTableIonManager;
    private int ionID;


    // Start is called before the first frame update
    void Start()
    {
        VictorySound = GameObject.Find("CorrectAnswerSound").GetComponent<AudioSource>();
        BondingArenaPosition = new Vector2(0, -1);

        X_OffsetOfThisAnion = -0.6f * transform.localPosition.x / transform.localScale.x;  //calculates X_Offset based on the prefab's construction
        Y_OffsetOfThisAnionTrigger = 0.6f * transform.localPosition.y / transform.localScale.y;

    }

    private void OnTriggerEnter2D(Collider2D other)  //the trigger is one of the AnionBondingTriggers attached as a child to the Anion GameObject
    {
        if (Vector3.Distance(gameObject.transform.position, BondingArenaPosition) < 3.3f)  //this means that the collision is occuring within the bonding arena
        {
            if (other.tag == "CationBondingTrigger") //other is the CationBondingTrigger, not the actual ion
            {
                //a Bond (relative joint) will be added to the anion

                BondingPartner = other.gameObject;  //this is the CationBondingTrigger (a child object of the Cation)
                //print("bonding partner = " + BondingPartner);
                BondingPartnerParentIon = BondingPartner.transform.parent.gameObject;  //this is the Atom that is the parent of the CationBondingTrigger

                CationTriggerOffset_Y = other.transform.position.y - BondingPartnerParentIon.transform.position.y;  //automatically calculates Y-offset of cation based on trigger location!

                CationTriggerOffset_X = other.transform.position.x - BondingPartnerParentIon.transform.position.x;  //automatically calculates X-offset of cation

                FinalY_Offset = Y_OffsetOfThisAnionTrigger - CationTriggerOffset_Y;
                FinalX_Offset = X_OffsetOfThisAnion + CationTriggerOffset_X;

                if (BondingPartnerParentIon.GetComponent<ValenceScript>().ionCharge + ParentIon.GetComponent<ValenceScript>().ionCharge == 0)
                {
                    FinalY_Offset = 0;  //align +2 and -2 ions instead of allowing staggered bonding image
                }
                //NEED TO MAKE A SIMILAR CORRECTION FOR THE LAST DIVALENT ION BONDING TO A TRIVALENT PARTNER--LINE 'EM UP!
                if (BondingPartnerParentIon.GetComponent<TrivalentIonScript>()) //a trivalent cation are bonding
                {
                    if (ParentIon.GetComponent<ValenceScript>().ionCharge == -2 && BondingPartnerParentIon.GetComponent<TrivalentIonScript>().BondingSitesRemaining == 2)
                    {
                        //a divalent anion is bonding with a trivalent cation that has two open bonding slots. . . 
                        print("need to align the ions here!");
                        if (ParentIon.transform.position.y > BondingPartnerParentIon.transform.position.y)
                        {
                            FinalY_Offset = -0.475f * 0.6f;  //this is the standard bonding offset (half of 0.95, which is half of 1.90, the standard ion height (y-dimension)
                        }
                        else
                        {
                            FinalY_Offset = +0.475f * 0.6f;
                        }
                    }

                    BondingPartnerParentIon.GetComponent<TrivalentIonScript>().FillABondingSite();  //this is always done, even if not a divalent anion that needs alignment
                }
                if (ParentIon.GetComponent<TrivalentIonScript>())  //a trivalent anion
                {
                    if (ParentIon.GetComponent<TrivalentIonScript>().BondingSitesRemaining == 2 && BondingPartnerParentIon.GetComponent<ValenceScript>().ionCharge == 2)
                    {
                        //a trivalent anion that has two open bonding slots is bonding with a divalent cation . . . 
                        print("need to align the ions here!");
                        if (ParentIon.transform.position.y > BondingPartnerParentIon.transform.position.y)
                        {
                            FinalY_Offset = -0.475f * 0.6f;  //this is the standard bonding offset (half of 0.95, which is half of 1.90, the standard ion height (y-dimension)
                        }
                        else
                        {
                            FinalY_Offset = +0.475f * 0.6f;
                        }
                    }

                    ParentIon.GetComponent<TrivalentIonScript>().FillABondingSite();  //this fills a slot on the trivalent anion even if not a divalent cation that needs alignment

                }

                //make a bond using relative joints--the joint is added only to the anion
                joint = ParentIon.AddComponent<RelativeJoint2D>();                 //joint links to centers of bonding atoms                                                               
                joint.connectedBody = BondingPartnerParentIon.GetComponent<Rigidbody2D>();     //parent of the "CationBondingTrigger"--the Rigidbody Cation


                joint.linearOffset = new Vector2(-FinalX_Offset, FinalY_Offset);
                joint.autoConfigureOffset = false;        //autoConfigureConnectedAnchor = false;              //if this bool is true, the joint won't hold when object is dragged!
                joint.enableCollision = false;
                joint.maxForce = 40000;
                //print("joint added");


                GameObject.Find("BondMadeSound").GetComponent<AudioSource>().Play();  //this plays a sound when ionic bond is formed

                ParentIon.GetComponent<IonicBondingScript>().UpdateVariablesAfterBondIsMade(BondingPartnerParentIon);  //THIS DOES ALL THE IMPORTANT "GAME" STUFF!!!


            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
