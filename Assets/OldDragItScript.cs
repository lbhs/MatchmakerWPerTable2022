using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
public class DragIt : MonoBehaviour
{
    private bool isDragging;
    private Vector2 mousePosition;
    private Vector2 initialMousePosition;
    private Vector2 MovePosition;
    private float deltaX;
    private float deltaY;
    private Rigidbody2D rb;
    public static bool DraggingDisabled;
    private Vector2 CationBoxCenterPoint = new Vector2(-5f, 4.2f);
    private Vector2 AnionBoxCenterPoint = new Vector2(5f, 4.2f);
    //public List<GameObject> CationsToInstatiate;
    public GameObject IonToInstantiate;
    private bool NoIonInStartingBox = true;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   //this atom is labeled "rb"

    }

    public void OnMouseDown()
    {
        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //deltaX = mousePosition.x - transform.position.x;
        //deltaY = mousePosition.y - transform.position.y;        
        StartDraggingThisObject();

    }

    public void OnMouseUp()
    {

    }

    public void StartDraggingThisObject()
    {
        initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        print(initialMousePosition);
        print(Vector2.Distance(initialMousePosition, CationBoxCenterPoint));
        if (Vector2.Distance(initialMousePosition, CationBoxCenterPoint) < 1)
        {
            print("clicked on cation box");
        }
        if (Vector2.Distance(initialMousePosition, AnionBoxCenterPoint) < 1)
        {
            print("clicked on anion box");
        }

        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        deltaX = initialMousePosition.x - transform.position.x;
        deltaY = initialMousePosition.y - transform.position.y;
    }

    public void ContinueDraggingThisObject()
    {

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (gameObject.tag == "NegativeIon" && DraggingDisabled == true)  //(gameObject.GetComponent<IonicBondingScript>() && gameObject.GetComponentInChildren<IonicBondingScript>().BondingEventInitiated == true)

        {
            print("Bonding Event disables rb.MovePosition in DragIt Script");  //this disables dragging of the ion while bonding event is occurring!

        }
        else
        {
            if (rb != null)
            {
                rb.MovePosition(new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY));  //this moves the ion according to the mouse position
            }

        }

        if (Vector2.Distance(mousePosition, initialMousePosition) > 3 && NoIonInStartingBox == true)
        {
            print("Time to Instantiate original cation/anion");
            //Instantiate(CationsToInstatiate[1]);
            Instantiate(IonToInstantiate, CationBoxCenterPoint, Quaternion.identity);
            NoIonInStartingBox = false;
        }
    }


    void OnMouseDrag()
    {
        ContinueDraggingThisObject();

        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if (gameObject.tag == "NegativeIon"  && DraggingDisabled == true)  //(gameObject.GetComponent<IonicBondingScript>() && gameObject.GetComponentInChildren<IonicBondingScript>().BondingEventInitiated == true)

        //{
        //    print("Bonding Event disables rb.MovePosition in DragIt Script");  //this disables dragging of the ion while bonding event is occurring!

        //}
        //else
        //{
        //    rb.MovePosition(new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY));  //this moves the ion according to the mouse position
        //}


    }



    // Start is called before the first frame update



    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;    //need this because the bonding event produces forces that create motion?!!!
        rb.angularVelocity = 0f;
    }
}*/
