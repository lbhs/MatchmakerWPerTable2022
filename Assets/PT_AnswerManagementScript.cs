using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class PT_AnswerManagementScript : MonoBehaviour
{
    //Attached to the AnswerManagementSystem GameObject

    public string[,] AnswerChoices = new string[21, 3];  //NEED TO UPDATE THE DIMENSIONS OF THE INDEX ON LINE 148!!!!
    public string[,] FormattedAnswerChoices = new string[21, 3];
    public GameObject AnswerButtonA;   //This is the actual button GameObject--can be set active or inactive
    public GameObject AnswerButtonB;
    public GameObject AnswerButtonC;
    private int i;
    private int j;

    //public int SaltID;  //this value is defined by PT_IonManagerScript

    public TMP_Text AnswerChoiceA;
    public TMP_Text AnswerChoiceB;
    public TMP_Text AnswerChoiceC;

    // Start is called before the first frame update
    void Start()
    {
        /*
         1 = sodium chloride
         2 = lithium sulfide
         3 = magnesium fluoride         
         4 = aluminum oxide
         5 = calcium iodide
         6 = potassium nitride

         7 = sodium oxide
         8 = strontium chloride
         9 = aluminum bromide
         10 = calcium phosphide
         11 = potassium iodide
         12 = lithium sulfide

         13 = rubidium fluoride
         14 = magnesium nitride
         15 = potassium sulfide
         16 = ??
         17 = ??
         18 = ??
         */

        AnswerChoices[1, 0] = "NaCl";   //Salt with Index #1 is sodium chloride.  Provide Three choices for the Buttons to Display
        AnswerChoices[1, 1] = "Na2Cl";
        AnswerChoices[1, 2] = "NaCl2";

        AnswerChoices[2, 0] = "LiS";
        AnswerChoices[2, 1] = "Li2S";
        AnswerChoices[2, 2] = "LiS2";

        AnswerChoices[3, 0] = "MgF";
        AnswerChoices[3, 1] = "MgF2";
        AnswerChoices[3, 2] = "Mg2F";

        AnswerChoices[4, 0] = "AlO3";
        AnswerChoices[4, 1] = "Al2O3";
        AnswerChoices[4, 2] = "Al3O2";

        AnswerChoices[5, 0] = "CaI";
        AnswerChoices[5, 1] = "Ca2I";
        AnswerChoices[5, 2] = "CaI2";

        AnswerChoices[6, 0] = "P3N2";
        AnswerChoices[6, 1] = "K3N";
        AnswerChoices[6, 2] = "KN3";

        AnswerChoices[7, 0] = "NaO";
        AnswerChoices[7, 1] = "Na2O";
        AnswerChoices[7, 2] = "NaO2";

        AnswerChoices[8, 0] = "SrCl";
        AnswerChoices[8, 1] = "Sr2Cl";
        AnswerChoices[8, 2] = "SrCl2";

        AnswerChoices[9, 0] = "AlBr2";
        AnswerChoices[9, 1] = "Al3Br";
        AnswerChoices[9, 2] = "AlBr3";

        AnswerChoices[10, 0] = "CaP2";
        AnswerChoices[10, 1] = "Ca3P2";
        AnswerChoices[10, 2] = "Ca2P3";

        AnswerChoices[11, 0] = "KI";
        AnswerChoices[11, 1] = "K2I";
        AnswerChoices[11, 2] = "KI2";

        AnswerChoices[12, 0] = "LiSO4";
        AnswerChoices[12, 1] = "Li2S";
        AnswerChoices[12, 2] = "Li2SO4";

        AnswerChoices[13, 0] = "MgSO4";
        AnswerChoices[13, 1] = "Mg2(SO4)";
        AnswerChoices[13, 2] = "Mg(SO4)2";

        AnswerChoices[14, 0] = "CuNO3";
        AnswerChoices[14, 1] = "Cu(NO)2";
        AnswerChoices[14, 2] = "Cu(NO3)2";

        AnswerChoices[15, 0] = "KBr";
        AnswerChoices[15, 1] = "KBr2";
        AnswerChoices[15, 2] = "K2Br2";

        AnswerChoices[16, 0] = "NaPO4";
        AnswerChoices[16, 1] = "Na3PO4";
        AnswerChoices[16, 2] = "Na3(PO)4";

        AnswerChoices[17, 0] = "FeCl2";
        AnswerChoices[17, 1] = "FeCl3";
        AnswerChoices[17, 2] = "Fe3Cl";

        AnswerChoices[18, 0] = "CaPO4";
        AnswerChoices[18, 1] = "Ca(PO4)2";
        AnswerChoices[18, 2] = "Ca3(PO4)2";

        AnswerChoices[19, 0] = "FeSO4";
        AnswerChoices[19, 1] = "Fe2SO4";
        AnswerChoices[19, 2] = "Fe2(SO4)3";

        AnswerChoices[20, 0] = "Mg3(PO4)";
        AnswerChoices[20, 1] = "Mg2(PO4)3";
        AnswerChoices[20, 2] = "Mg3(PO4)2";

        GenerateFormattedAnswerChoices();
       
    }

    public void GenerateFormattedAnswerChoices()
    {
        for (i = 1; i < 21; i++)   //THIS i VALUE MUST GO AS HIGH AS THE NUMBER OF SALTS IN THE SYSTEM!!!!!
        {
            for (j = 0; j < 3; j++)
            {
                if (AnswerChoices[i, j] != null)
                {
                    //print(AnswerChoices[i, j]);
                    ConvertNameToTMP(AnswerChoices[i, j]);
                    FormattedAnswerChoices[i, j] = ConvertNameToTMP(AnswerChoices[i, j]);  //this function adds the subscripts to chemical formulas!
                    //print(FormattedAnswerChoices[i, j]);
                }

            }

        }
    }

    private string ConvertNameToTMP(string name)
    {
        string result = "";
        for (int i = 0; i < name.Length; i++)
        {
            if (Char.IsDigit(name[i]))
            {
                result += string.Format("<sub>{0}</sub>", name[i]);
            }
            else
            {
                result += name[i];
            }
        }
        return result;
    }



    public void DisplayAnswerChoices(int SaltID)  //This function is called from the NetChargeCalculator script
    {
        print("Salt ID = " + SaltID);
        AnswerButtonA.SetActive(true);
        AnswerButtonB.SetActive(true);
        AnswerButtonC.SetActive(true);

        AnswerChoiceA.text = FormattedAnswerChoices[SaltID, 0];
        AnswerChoiceB.text = FormattedAnswerChoices[SaltID, 1];
        AnswerChoiceC.text = FormattedAnswerChoices[SaltID, 2];

        AnswerButtonA.GetComponent<Button>().interactable = true;
        AnswerButtonB.GetComponent<Button>().interactable = true;
        AnswerButtonC.GetComponent<Button>().interactable = true;

        print(AnswerChoiceA.text);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
