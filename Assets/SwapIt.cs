using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapIt : MonoBehaviour
{
    public GameObject PrefabToBecome;
    private Vector3 InitalPos;
    private float DistanceThreshold = 0.2f; //must be within 0.2 units of initial position to be swappable so it doesn't swap while atom is moving
    private float timeThreshold = 1.0f; //hold down for this many seconds to switch atom type
    private bool heldDown = false;
    private Coroutine currentTimer;
    public static bool DisableSwap;


    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1) && gameObject.GetComponent<BondMaker>().bonded == false && DieScript.RotateMessageGiven > 3)  //Right Click can trigger Swap
        {
            if (GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().Tutorial && DieScript.RotateMessageGiven < 4)
            {
                print("can't swap until 4 rotations");
            }
            else
            {
                swapAtom();
                DieScript.SwitchAtomMessageGiven++;   //When SwitchAtomMessage has been given at least 2 times, tutorial can proceed
            }
        }


    }


    private void OnMouseDown()
    {
        heldDown = true;
        InitalPos = transform.position;
        currentTimer = StartCoroutine(seeIfStillHeldDown());  //long click is used to swap atom forms
    }

    private void OnMouseUp()
    {
        heldDown = false;
        StopCoroutine(currentTimer);
    }

    private IEnumerator seeIfStillHeldDown()  //Long Click can also trigger Swap
    {
        {
            yield return new WaitForSeconds(timeThreshold);
            float distance = Vector3.Distance(InitalPos, transform.position);
            if (heldDown && distance < DistanceThreshold && gameObject.GetComponent<BondMaker>().bonded == false)
            {
                if (GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().Tutorial && DieScript.RotateMessageGiven < 4)
                {
                    print("can't swap until 4 rotations");
                }
                else
                {
                    swapAtom();
                    DieScript.SwitchAtomMessageGiven++;   //When SwitchAtomMessage has been given at least 2 times, tutorial can proceed
                }


            }
            heldDown = false;
        }
    }

    public void swapAtom()
    {
        if (DisableSwap == true)
        {
            return;
        }

        Instantiate(PrefabToBecome, transform.position, Quaternion.identity);

        if (GameObject.Find("TutorialMarker").GetComponent<TutorialScript>().Tutorial == true && DieScript.totalRolls == 1)
        {
            if (DieScript.SwitchAtomMessageGiven >= 2 && gameObject.name == "CarbonE(Clone)")
            {
                DisableSwap = true;   //in tutorial, disable swap atom and rotate atom so that player doesn't miss messages or make bonding impossible
                print("disabled swap");
                RotateThis.DisableRotation = true;
                print("disabled rotation");

                //GameObject.Find("CarbonEsp2(Clone)").GetComponent<BondMaker>().bonded = true;  //this disables rotation or swap on the tutorial carbon atom
                //print("activated bonded state from SwapAtom script");
                GameObject.Find("ConversationDisplay").GetComponent<ConversationTextDisplayScript>().BlueJoulesArePE();
            }
        }
        Destroy(gameObject);
    }
}
