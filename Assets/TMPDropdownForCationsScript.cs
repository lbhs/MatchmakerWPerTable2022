using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMPDropdownForCationsScript : MonoBehaviour
{
    public TMP_Dropdown CationSelectorDropdown;
    public List<GameObject> CationToEnable;



    public void SelectCationFromDropdown()
    {
        if (CationSelectorDropdown.value == 0)
        { return; }

        else
        {

            print("Cation selected = " + CationSelectorDropdown.value);
            CationToEnable[CationSelectorDropdown.value].SetActive(true);

            CationSelectorDropdown.interactable = false;
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
