using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class DragIt : MonoBehaviour   //, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    //DragIt Script is attached to every ion (cation or anion).  IonID no longer used
    private Vector2 mousePosition;
    private Vector2 initialMousePosition;
    private Vector2 MovePosition;
    private float deltaX;
    private float deltaY;
    private Rigidbody2D rb;
    //public static bool DraggingDisabled;  //this needs to be in a UNIQUE location. . .  Put it on MoleculeListKeeper?
    private Vector2 CationBoxCenterPoint = new Vector2(-5f,4.2f);
    private Vector2 AnionBoxCenterPoint = new Vector2(5f,4.2f);
    private Vector2 BondingArenaCenter = new Vector2(0, -2);
    //public List<GameObject> ListOfIonsToInstantiate = new List<GameObject>();
    public int IonID;
    //public GameObject IonToInstantiate;
    public static bool CationDraggedOutFromStartingBox = false;
    public static bool AnionDraggedOutFromStartingBox = false;
    //public GameObject LastCationInstantiated;  //this variable is kept by the TMPDrowdownSaltSelectorScript 
    //public GameObject LastAnionInstantiated;   //this variable is kept by the TMPDrowdownSaltSelectorScript 
    public TMP_Dropdown DropdownSaltSelector;
    public GameObject TMPDropdownForSalts;  //instantiates the new versions of Cation or Anion after dragging is completed
    public TMP_Text TextBoxForAnswers;
   
    

    /*List of IonID values:  These are defined as a public array in the TMPDrowdownSelectorScript  used when instantiating a new copy of the dragged ion!
    0 = Na+
    1 = Mg+2
    2 = Al+3
    3 = K+1
    4 = Cu+2
    5 = Fe+3
    6 = Cl-1
    7 = O-2
    8 = N-3
    9 = NO3-1
    10 = SO4-2
    11 = PO4-3
    12 = Br-1
    13 = Ca+2
    14 = 
    15 = 

    */

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   //this atom is labeled "rb"
        TMPDropdownForSalts = GameObject.Find("TMP DropdownForSalts");

    }

    public void OnMouseDown()  //MAKE IT SO ONLY TWO UNBONDED IONS CAN EXIST WITHIN THE BONDING ARENA
    {
        if (NetChargeCalculatorScript.DraggingDisabled == false )  //If Dragging is Disabled, don't allow a new click and drag  to begin. NEED TO MAKE THIS BETTER--MOLECULECOMPLETED BOOLEAN?
        {
            IonicBondingScript.BondHappened = false;
            initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //print(initialMousePosition);        
            //print(Vector2.Distance(initialMousePosition, CationBoxCenterPoint));

            if (Vector2.Distance(initialMousePosition, CationBoxCenterPoint) < 1.5f)
            {
                //print("clicked on cation box");
                CationDraggedOutFromStartingBox = true;  //if true, a new ion will be instantiated when mouse drag ends (OnMouseUp)
                
            }

            if (Vector2.Distance(initialMousePosition, AnionBoxCenterPoint) < 1.5f)
            {
                //print("clicked on anion box");
                AnionDraggedOutFromStartingBox = true;
            }

            deltaX = initialMousePosition.x - transform.position.x;  //this allows the initial ion in the box to be dragged with an offset relative to the initial mouse click
            deltaY = initialMousePosition.y - transform.position.y;
        }
        


    }    

    public void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if ((gameObject.tag == "NegativeIon" || gameObject.tag == "PositiveIon") && DraggingDisabled == true)  //DraggingDisabled is set to "true" in the IonicBondingScript once a bonding event is initiated

        if(NetChargeCalculatorScript.DraggingDisabled == true)
        {
            //print("DraggingDisabled");  //this disables dragging of the ion while bonding event is occurring!  This allows the ions to move naturally and make bonds
            //Dragging is also disabled when the salt structure with proper formula has been completed--will be enabled once a new salt has been chosen

        }
        else
        {
            if (rb != null)
            {
                rb.MovePosition(new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY));  //this moves the ion according to the mouse position
            }

        }      

    }

    public void OnMouseUp()   //End of Drag
    {
        //On end of drag, check to see if two unbonded ions already exist in bonding arena.  If so, snap back to starting position
        //On end of drag, if a bond has been formed, a new copy of the chosen cation or chosen anion will be instantiated in the original box!
        if (CationDraggedOutFromStartingBox == true)  //This verifies that a new cation is being dragged
        {  
            if (Vector2.Distance(mousePosition, BondingArenaCenter) < 4.3f)  //this means the ion will be dropped within the bonding arena
            {
                if (IonicBondingScript.BondHappened == false && GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().AllIonsInScene.Count > 2)
                {
                    print("This ion should go back to start.  No bond happened!");  //if No bond happened, the ion should not remain in bonding arena (unless it is the first ion dropped into the arena!)
                    gameObject.transform.position = CationBoxCenterPoint;  //sends the ion back to its starting point
                    CationDraggedOutFromStartingBox = false;  //the ion is back in its box, so this boolean is false now
                    GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().color = Color.yellow;
                    GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = "When you drag an ion into the Arena, you should make a Bond!";
                    return;
                }
                else
                {
                    //print("Time to Instantiate original cation in the cation display box");
                    GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = null;
                    TMPDropdownForSalts.GetComponent<TMPDrowdownSaltSelectorScript>().InstantiateNewCation();  //instantiation is managed by TMPDrowdownSaltSelectorScript
                    
                    CationDraggedOutFromStartingBox = false;  //the ion in the CationDisplayBox has been restored
                   
                }
                
            }
            else  //if not dropped within the bonding arena, the ion goes back to its starting position and a message tells the user to use the Bonding Arena
            {
                print("You must drop ions into the Bonding Arena!");
                GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().color = Color.white;
                GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = "You must drop ions into the Bonding Arena!";
                gameObject.transform.position = CationBoxCenterPoint;
                CationDraggedOutFromStartingBox = false;  //the ion in the CationDisplayBox has snapped back to its original position
            }
        }
            
            
        

        if (AnionDraggedOutFromStartingBox == true)
        {
            if (Vector2.Distance(mousePosition, BondingArenaCenter) < 4.3f)
            {
                if (IonicBondingScript.BondHappened == false && GameObject.Find("TMP DropdownForSalts").GetComponent<TMPDrowdownSaltSelectorScript>().AllIonsInScene.Count > 2)
                {
                    //print("This ion should go back to start.  No bond happened!");
                    gameObject.transform.position = AnionBoxCenterPoint;
                    AnionDraggedOutFromStartingBox = false;
                    GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().color = Color.yellow;
                    GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = "When you drag an ion into the Arena, you should make a Bond!";
                    return;
                }
                else
                {
                    //print("anion dropped into bonding arena");
                    GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = null;
                    TMPDropdownForSalts.GetComponent<TMPDrowdownSaltSelectorScript>().InstantiateNewAnion();  //instantiation is managed by TMPDrowdownSaltSelectorScript
                    AnionDraggedOutFromStartingBox = false;  //the original anion has been replaced!
                    
                }
                
            }
            else  //if not dropped within the bonding arena, the ion goes back to its starting position and a message tells the user to use the Bonding Arena
            {
                print("You must drop ions into the Bonding Arena!");
                GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().color = Color.white;
                GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = "You must drop ions into the Bonding Arena!";
                gameObject.transform.position = AnionBoxCenterPoint;
                AnionDraggedOutFromStartingBox = false;  //the original anion has snapped back to its starting position!
            }

        }
         
            
            
            
            
      
        
        
       

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;    //need this because the bonding event produces forces that create motion?!!!
        rb.angularVelocity = 0f;
    }


    
    
}
