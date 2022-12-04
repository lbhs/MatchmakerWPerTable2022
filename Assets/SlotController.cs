using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotController : MonoBehaviour
{
    [SerializeField]
    private GameObject slot1;

    [SerializeField]
    private GameObject slot2;

    private float slotWidth;

    private float slot1Height;
    private float slot2Height;

    private int slotOccupancy;   //if 1, put the next trophy in the top slot (Slot 1), if 2, put the trophy in the bottom slot (Slot 2)

    public void PlaceImageInSlot(Sprite moleculeImage)  //this function is called from AnswerKeyScript
    {
        if (slotOccupancy == 1)
        {
            slot1.GetComponent<SpriteRenderer>().sprite = moleculeImage;
            slotOccupancy = 2;
        }
        else
        {
            slot2.GetComponent<SpriteRenderer>().sprite = moleculeImage;
            slotOccupancy = 1;
        }
    }
        

    // Start is called before the first frame update
    void Start()
    {
        //slotWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        //print("slotWidth = " + slotWidth);

        //slot1Height = slot1.GetComponent<SpriteRenderer>().bounds.size.y;
        //slot2Height = slot2.GetComponent<SpriteRenderer>().bounds.size.y;
        //print("slot1Height = " + slot1Height);
        //print("slot2Height = " + slot2Height);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
