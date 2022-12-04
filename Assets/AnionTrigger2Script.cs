using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnionTrigger2Script : MonoBehaviour
{
    public bool Trigger2Active;
    public float Y_OffsetThisTrigger;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        print("Trigger2 activated");
        Trigger2Active = true;
        print("Y_OffsetThisTrigger = " + Y_OffsetThisTrigger);
        GameObject ParentIon = transform.parent.gameObject;
        ParentIon.GetComponent<IonicBondingScript>().Y_OffsetOfThisIon = Y_OffsetThisTrigger;
        //gameObject.GetComponentInParent<IonicBondingScript>().Y_OffsetOfThisIon = -0.265f;  //should be -0.465
        print("Y-offset of the Ion = " + ParentIon.GetComponent<IonicBondingScript>().Y_OffsetOfThisIon);
    }
}
