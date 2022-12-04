using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PT_NetChargeCalculatorScript : MonoBehaviour  //This Script is Attached to the GameObject MoleculeListKeeper
{
    public List<GameObject> ListOfBondedIonsInThisMolecule = new List<GameObject>();  //This is the list of ions that have been bonded together for this salt
    private int i;  //for index
    public int netChargeOfMolecule;
    public int SaltID;  //identified in the TMPDrowdownSaltSelectorScript--duplicated here for convenience
    private GameObject UnusedCation;
    private GameObject UnusedAnion;
    public static bool DraggingDisabled;  //this needs to be in a UNIQUE location. . .  Put it on MoleculeListKeeper?

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
