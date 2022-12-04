using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RotateThis : MonoBehaviour
{
    private float holdTime = 0;
    private Vector2 initialMousePosition;
    private Vector2 finalMousePosition;

    public const double holdTimeThreshold = 0.2; //let go within 0.2 seconds to rotate--no longer valid in this Shahrestany-modified script
    public static bool DisableRotation;


    private void OnMouseDown()
    {
        holdTime = 0;
        initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    void Update()
    {
        holdTime += Time.deltaTime;
    }
    private void OnMouseUp()
    {
        finalMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (JewelMover.JewelsInMotion == true  || DisableRotation == true)
        {  //disable rotation while jewels are moving
            print("Can't rotate while jewels are moving");
            return;
        }

        else if (Math.Abs(initialMousePosition.x - finalMousePosition.x) < 0.1 && Math.Abs(initialMousePosition.y - finalMousePosition.y) < 0.1)
        {
            if (gameObject.GetComponent<BondMaker>().bonded == false)
            {
                if (gameObject.tag == "CO2")
                {
                    transform.Rotate(0, 0, -45);
                }
                else
                {
                    transform.Rotate(0, 0, 90);
                    DieScript.RotateMessageGiven++;   //used for tutorial to indicate the 4 rotations needed to proceed 
                    if (DieScript.totalRolls == 1 && DieScript.RotateMessageGiven > 3)
                    {
                        GameObject.Find("ConversationDisplay").GetComponent<ConversationTextDisplayScript>().SwitchAtomForm();
                    }
                }
                
            }
        }


    }
}


