using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PT_DragIt : MonoBehaviour
{
    //PT_DragIt Script is attached to every ion (cation or anion).  IonID is assigned to each prefab ion using this script!
    //Also assigns the ion position (on the periodic table) using world space coordinates)
    private Vector2 mousePosition;
    private Vector2 initialMousePosition;
    private Vector2 MovePosition;
    private float deltaX;
    private float deltaY;
    private Rigidbody2D rb;
    
    public Vector2 InitialIonPosition;
    private Vector2 BondingArenaCenter = new Vector2(0, 0);
       
    public int IonID;

    public GameObject PerTableIonManager;
    public GameObject MoleculeListKeeper;
    public GameObject PerTableAnswerManager;
    public Button SubmitAnswerButton;
    //public Button ClearArenaButton;

    private GameObject LastIonInstantiated;
    private GameObject LastCationInstantiated;
    private GameObject LastAnionInstantiated;
        
    public TMP_Text TextBoxForAnswers;
    private Vector2 OffsetVector;
    private int i;

    public bool DragStartedInsideTheArena; //If dragging an ion pair within the bonding arena, no bond will be made, so no message should be given
    public bool NonBinarySaltWarning;  //if user tries to make a ternary salt (e.g. LiNaS)


    /*List of IonID values:  These are defined as a public array in the //PERIODICTABLEIONLISTKEEPER \\TMPDrowdownSelectorScript//  used when instantiating a new copy of the dragged ion!
    0 = Li+
    1 = Na+1
    2 = K+1
    3 = Rb+1
    4 = Mg+2
    5 = Ca+2
    6 = Sr+2 
    7 = Al+3
    8 = Ga+3
    9 = F-1
    10 = Cl-1
    11 = Br-1
    12 = I-1
    13 = O-2
    14 = S-2
    15 = N-3
    16 = P-3
    18 = Se-2

    */

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();   //this atom is labeled "rb"
        PerTableIonManager = GameObject.Find("PerTableIonManager");
        MoleculeListKeeper = GameObject.Find("MoleculeListKeeper");
        PerTableAnswerManager = GameObject.Find("PerTableAnswerManager");
        //ClearArenaButton = GameObject.Find("ClearBondingArenaButton").GetComponent<Button>();
        //InitialIonPosition is defined for each prefab based on the position of the ion on the periodic table grid (world space coordinates)

    }

    public void OnMouseDown()  //MAKE IT SO ONLY TWO UNBONDED IONS CAN EXIST WITHIN THE BONDING ARENA
    {
        if (PerTableIonManager.GetComponent<PT_IonManagerScript>().PT_IonsInBondingArena.Count >= 2 && IonID != PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().CationID && IonID != PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().AnionID)
        {
            //this means that the user is trying to make a non-binary salt (e.g. MgClF or NaLiS).  Disallow this.
            //print("The ion you are adding doesn't match the previous ions used");
            GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().color = Color.yellow;
            GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = "That ion doesn't match the ions already in the Arena.";
            NonBinarySaltWarning = true;
            return;
        }

        else
        {
            GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = null;
        }
       
        IonicBondingScript.BondHappened = false;
        
        initialMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        deltaX = transform.position.x - initialMousePosition.x;  //this allows the initial ion in the box to be dragged with an offset relative to the initial mouse click
        deltaY = transform.position.y - initialMousePosition.y;
        OffsetVector = new Vector2(deltaX, deltaY);

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);           
        if ((Vector2.Distance(mousePosition, BondingArenaCenter) < 3f)) //this means that the dragging starts within the bonding arena
        {                
            DragStartedInsideTheArena = true;  //this variable is checked in line 131 of this script
        }
        else
        {
            DragStartedInsideTheArena = false;
            //NEW ON NOV 29, 2022 -- NOT NEEDED, USING SPRITE RENDERER ORDER IN LAYER TO SORT THE IONS IN THE Z-DIRECTION
            //print("ion moved to z = -1");
            //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -1);  //pop the dragged ion out in front of the other ions
        }             
    }

    public void OnMouseDrag()
    {
        
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //if ((gameObject.tag == "NegativeIon" || gameObject.tag == "PositiveIon") && DraggingDisabled == true)  //DraggingDisabled is set to "true" in the IonicBondingScript once a bonding event is initiated

        if (NetChargeCalculatorScript.DraggingDisabled == true || NonBinarySaltWarning)
        {
            //print("DraggingDisabled");  //this disables dragging of the ion while bonding event is occurring!  This allows the ions to move naturally and make bonds
            //Dragging is also disabled when the salt structure with proper formula has been completed--will be enabled once a new salt has been chosen

        }
        else
        {
            if (rb != null)
            {
                rb.MovePosition(new Vector2(mousePosition.x + deltaX, mousePosition.y + deltaY));  //this moves the ion according to the mouse position
                rb.MovePosition(mousePosition + OffsetVector);
            }
        }
        

    }

    public void OnMouseUp()   //End of Drag
    {
        //On end of drag:  First check to see if the drag ends inside the bonding arena.
        //Then check to see if a the newly dragged-in ion made a bond with previous ion(s)
        //Then check to see if the newly dragged ion matches an existing ion (no ternary salts allowed)         
        //On end of drag, if a bond has been formed, a new copy of the chosen cation or chosen anion will be instantiated in the original box!
        //Info on the ions within the salt is kept by the PerTableIonManager GameObject -- InfoAboutIonsInTheArena Script
        
        rb.velocity = Vector3.zero;    //need this because the bonding event produces forces that create motion?!!!
        rb.angularVelocity = 0f;
        if (NonBinarySaltWarning)
        {
            //print("NonBinarySalt");
            StartCoroutine(CountdownToClearWarning());
            NonBinarySaltWarning = false;  //this resets to allow the user to drag a proper ion
            return;
        }

        if (Vector2.Distance(mousePosition, BondingArenaCenter) > 3f)  //this means the ion will be dropped OUTSIDE the bonding arena  
        {   
            //if not dropped within the bonding arena, the ion goes back to its starting position and a message tells the user to use the Bonding Arena
            if (!NetChargeCalculatorScript.DraggingDisabled)
            {
                //print("You must drop ions inside the Bonding Arena!");
                GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().color = Color.white;
                GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = "You must put ions Inside the Bonding Arena!";
                Vector2 TargetPosition = initialMousePosition + OffsetVector;
                StartCoroutine(MoveRigidbodyToTargetSite(TargetPosition));  //this is better than using transform.position, as it takes a few frames to get an ion complex back to its proper position
            }
        }

        else //this means the ion will be dropped within the bonding arena
        {
            
            if (DragStartedInsideTheArena == false) //presumably, this means a "new" ion is being dragged from the periodic table
            {
                if (PerTableIonManager.GetComponent<PT_IonManagerScript>().PT_IonsInBondingArena.Count > 0 && IonicBondingScript.BondHappened == false)                
                {
                    print("This ion should go back to start.  No bond happened!");  //if No bond happened, the ion should not remain in bonding arena (unless it is the first ion dropped into the arena!)
                    gameObject.transform.position = initialMousePosition + OffsetVector;     //sends the ion back to its starting point

                    GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().color = Color.yellow;
                    GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = "When you drag an ion into the Arena, you should make a Bond!";
                    return;
                }
                    

                else  //this even has passed all the checks--the user is doing the right thing!!!
                {
                    print("Time to Instantiate original cation in its original display box");
                    PerTableAnswerManager.GetComponent<PeriodicTableAnswerScript>().ActivateClearArenaButton();
                    //ClearArenaButton.interactable = true;
                    GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = null;
                    if(PerTableIonManager.GetComponent<PT_IonManagerScript>().PT_IonsInBondingArena.Count == 0)
                    {
                        print("first ion in--add to ListOfBondedIons");
                        MoleculeListKeeper.GetComponent<NetChargeCalculatorScript>().ListOfBondedIonsInThisMolecule.Add(gameObject);
                        MoleculeListKeeper.GetComponent<NetChargeCalculatorScript>().CalculateNetCharge();
                    }

                    //THE LINE BELOW USES IonID, which is only used in the Periodic Table Scene
                    print("IonID = " + IonID);
                    LastIonInstantiated = Instantiate(PerTableIonManager.GetComponent<PT_IonManagerScript>().PT_ListOfIonsToInstantiate[IonID], InitialIonPosition, Quaternion.identity);  //IonToInstantiate is a copy of the currently dragged gameObject--this is set in the list of IonIdentities kept on the TMPDrowdownSaltSelectorScript

                    if (gameObject.tag == "PositiveIon")
                    {
                        PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().CationCharge = GetComponent<ValenceScript>().ionCharge;
                        PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().CationID = IonID;
                        PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfCations++;
                    }
                    else if (gameObject.tag == "NegativeIon")
                    {
                        PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().AnionCharge = GetComponent<ValenceScript>().ionCharge;
                        PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().AnionID = IonID;
                        PerTableIonManager.GetComponent<InfoAboutIonsInTheArena>().NumberOfAnions++;
                    }
                    PerTableIonManager.GetComponent<PT_IonManagerScript>().PT_IonsInBondingArena.Add(gameObject);
                    
                    if (MoleculeListKeeper.GetComponent<NetChargeCalculatorScript>().netChargeOfMolecule == 0)  //Molecule Complete!  User may submit answer now.
                    {
                        //print("looking for SubmitAnswerButton");
                        SubmitAnswerButton = GameObject.Find("SubmitAnswerButton").GetComponent<Button>();
                        SubmitAnswerButton.interactable = true;
                        //PerTableAnswerManager.GetComponent<PeriodicTableAnswerScript>().CheckAnswerForPeriodicTableQuestion();
                    }
                }
            }


            //print("Count of ions in bonding arena= " + PerTableIonManager.GetComponent<PT_IonManagerScript>().PT_IonsInBondingArena.Count);
        }
                

        

        
    }

    public IEnumerator MoveRigidbodyToTargetSite(Vector2 TargetPosition)
    {
        print("MpveRigidbodyToTargetSiteCoroutine");
        while(rb.position != TargetPosition)
        {
            print("moving rigidbody");
            print(TargetPosition);
            print(rb.position);
            rb.MovePosition(TargetPosition);
            yield return 0;
        }     
    }
    
    public IEnumerator CountdownToClearWarning()
    {
        yield return new WaitForSeconds(2);
        GameObject.Find("AnswerFeedbackDisplay").GetComponent<TMP_Text>().text = null;
    }
   
    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector3.zero;    //need this because the bonding event produces forces that create motion?!!!
        //rb.angularVelocity = 0f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    
}
