using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

//DESKTOP VERSION
public class AnswerManagementScript : MonoBehaviour
{
    public string[,] AnswerChoices = new string[21, 3];  //NEED TO UPDATE THE DIMENSIONS OF THE INDEX ON LINE 148!!!!
    public string[,] FormattedAnswerChoices = new string[21, 3];
    public GameObject AnswerButtonA;   //This is the actual button GameObject
    public GameObject AnswerButtonB;
    public GameObject AnswerButtonC;
    private int i;
    private int j;

    public int SaltID;

    //public Button AnswerButtonC;   //better to refer to the AnswerButtons as GameObjects so that I can easily use SetActive function!

    public TMP_Text AnswerChoiceA;
    public TMP_Text AnswerChoiceB;
    public TMP_Text AnswerChoiceC;

    // Start is called before the first frame update
    void Start()
    {
        /*
         1 = sodium chloride
         2 = sodium oxide
         3 = sodium phosphate
         4 = magnesium oxide
         5 = magnesium chloride
         6 = copper chloride
         7 = aluminum chloride
         8 = aluminum oxide
         9 = aluminum nitrate
         10 = copper nitrate
         11 = sodium sulfate
         12 = aluminum sulfate
         13 = magnesium sulfate
         14 = magnesium phosphate   
         */ 
      
        //Going to try using ONE Master List for all the salts used in the 3 scenes.  Will need to manually assign the index value for each scene
        //Scene 1 uses AnswerChoices 1-6,   Scene 2 uses AnswerChoices 7-12,  Scene 3 uses AnswerChoices 13-18

        AnswerChoices[1, 0] = "NaCl";   //Salt with Index #1 is sodium chloride.  Provide Three choices for the Buttons to Display
        AnswerChoices[1, 1] = "Na2Cl";
        AnswerChoices[1, 2] = "NaCl2";

        AnswerChoices[2, 0] = "KS";
        AnswerChoices[2, 1] = "K2S";
        AnswerChoices[2, 2] = "KS2";

        AnswerChoices[3, 0] = "MgBr";
        AnswerChoices[3, 1] = "MgBr2";
        AnswerChoices[3, 2] = "Mg2Br";

        AnswerChoices[4, 0] = "CuO";
        AnswerChoices[4, 1] = "Cu2O";
        AnswerChoices[4, 2] = "CuO2";

        AnswerChoices[5, 0] = "AlO2";
        AnswerChoices[5, 1] = "Al2O3";
        AnswerChoices[5, 2] = "Al3O2";
       
        AnswerChoices[6, 0] = "CaN2";
        AnswerChoices[6, 1] = "Ca3N";
        AnswerChoices[6, 2] = "Ca3N2";

        AnswerChoices[7, 0] = "LiCO3";
        AnswerChoices[7, 1] = "Li2CO3";
        AnswerChoices[7, 2] = "Li(CO3)2";

        AnswerChoices[8, 0] = "CaNO3";
        AnswerChoices[8, 1] = "Ca(NO3)2";
        AnswerChoices[8, 2] = "Ca(NO)2";

        AnswerChoices[9, 0] = "CuOH";
        AnswerChoices[9, 1] = "CuOH2";
        AnswerChoices[9, 2] = "Cu(OH)2";

        AnswerChoices[10, 0] = "Na3PO4";
        AnswerChoices[10, 1] = "Na3(PO4)";
        AnswerChoices[10, 2] = "Na3(PO4)2";

        AnswerChoices[11, 0] = "FeSO4";
        AnswerChoices[11, 1] = "Fe2SO4";
        AnswerChoices[11, 2] = "Fe2(SO4)3";

        AnswerChoices[12, 0] = "SnPO4";
        AnswerChoices[12, 1] = "Sn2(PO4)3";
        AnswerChoices[12, 2] = "Sn3(PO4)2";

        AnswerChoices[13, 0] = "SnPO4";
        AnswerChoices[13, 1] = "Sn2(PO4)3";
        AnswerChoices[13, 2] = "Sn3(PO4)2";

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

        //for (i = 1; i<16; i++)
        //{
        //    for (j = 0; j<3; j++)
        //    {
        //        if(AnswerChoices[i,j] != null)
        //        {
        //            //print(AnswerChoices[i, j]);
        //            //ConvertNameToTMP(AnswerChoices[i, j]);
        //            FormattedAnswerChoices[i, j] = ConvertNameToTMP(AnswerChoices[i, j]);  //this function adds the subscripts to chemical formulas!
        //            //print(FormattedAnswerChoices[i, j]);
        //        }

        //    }

        //}

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
                    //ConvertNameToTMP(AnswerChoices[i, j]);
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



    public void DisplayAnswerChoices(int SaltID)  //(int AnionID, int CationID)
    {
        AnswerButtonA.SetActive(true);
        AnswerButtonB.SetActive(true);
        AnswerButtonC.SetActive(true);
        
        AnswerChoiceA.text = FormattedAnswerChoices[SaltID,0];
        AnswerChoiceB.text = FormattedAnswerChoices[SaltID,1];
        AnswerChoiceC.text = FormattedAnswerChoices[SaltID,2];
    }     
        

    // Update is called once per frame
    void Update()
    {
        
        
    }
}
