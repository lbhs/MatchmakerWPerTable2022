﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SaltNameScript : MonoBehaviour  //attached to TMPDropdownSaltSelector GameObject (now hidden offscreen)
{
    public List<string> SaltNames;  //list the names that are used in this scene--may make a universal list good for all scenes--then say where in the list to start reading
    public TMP_Text SaltNameDisplay;  //a text box near the top of the screen
    public int SaltNumberToStartThisScene;  //this allows use of the universal list
    public Button AdvanceToNextSaltButton;  //made interactable when a correct answer has been given
    public GameObject AnswerManagementSystem;  //the AnswerManagementSystem GameObject keeps the variable WhichSaltAreWeOn (AnswerKeyScript)


    // Start is called before the first frame update
    void Start()
    {
        //SaltNumberToStartThisScene is kept in AnswerManagementSystem variable IDNumberOfFirstSalt
        SaltNameDisplay.text = "Salt Name: <br>" + SaltNames[AnswerManagementSystem.GetComponent<AnswerKeyScript>().IDNumberOfFirstSalt];
        AdvanceToNextSaltButton.interactable = false;
        GetComponent<TMPDrowdownSaltSelectorScript>().ShowTheFirstSalt();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateSaltName()  //called from the AdvanceToNextSalt Button
    {
        AdvanceToNextSaltButton.interactable = false;
        SaltNameDisplay.text = "Salt Name: <br>" + SaltNames[AnswerManagementSystem.GetComponent<AnswerKeyScript>().WhichSaltAreWeOn];
        GetComponent<TMPDrowdownSaltSelectorScript>().ShowTheNextSalt();
    }
}
