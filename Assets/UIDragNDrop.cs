using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIDragNDrop : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public bool returnToZero = false; //default value is false
    public GameObject PrefabToSpawn;
    public bool UseingMe;
	Vector3 prefabWorldPosition;
    public static int BondableAtomsTakenSoFar;
    private GameObject NewAtom;




    void Start()
	{
		
	}

    public void OnBeginDrag(PointerEventData eventData)
    {
        prefabWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        prefabWorldPosition.z = 0;
        NewAtom = Instantiate(PrefabToSpawn, prefabWorldPosition, Quaternion.identity);
        //NewAtom.GetComponent<DragIt>().StartDraggingThisObject();  //THIS FUNCTION IS OBSOLETE WHEN USING THE REAL RIGIDBODY GAME OBJECTS
    }

    public void OnDrag(PointerEventData eventData)
    {
        //NewAtom.GetComponent<DragIt>().ContinueDraggingThisObject();  //THIS FUNCTION IS OBSOLETE WHEN USING THE REAL RIGIDBODY GAME OBJECTS
        //if(!GameObject.Find("UI").GetComponent<Animator>().GetBool("Exiting"))

        //transform.position = Input.mousePosition;
        //UseingMe = true;          

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        ////prefabWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        ////prefabWorldPosition.z = 0;
        ////Instantiate(PrefabToSpawn, prefabWorldPosition, Quaternion.identity);
        if (returnToZero == true)
        {
            transform.localPosition = Vector3.zero;
        }
        UseingMe = false;
    }

}