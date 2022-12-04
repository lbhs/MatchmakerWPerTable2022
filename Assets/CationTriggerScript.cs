using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CationTriggerScript : MonoBehaviour
{
    public bool TriggerActivated;
    public GameObject ParentCation;

    // Start is called before the first frame update
    void Start()
    {
        ParentCation = transform.parent.gameObject;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)  //THIS IS MEANINGLESS, I THINK. . .  NOT SHRINKING THE COLLIDERS ANYMORE?!
    {
        if (otherCollider.tag == "AnionBondingTrigger")
        {
            TriggerActivated = true;
            //gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(0, 0);
            //print("Cation Trigger Activated and shrunken =" + gameObject);            
            
        }
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
