using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownForCationsScript : MonoBehaviour
{
    public Dropdown CationSelectorDropdown;
    public List<GameObject> CationsToEnable = new List<GameObject>();
    //public List<GameObject> CationImagesList = new List<GameObject>();
    //public List<GameObject> PrefabsToInstantiate = new List<GameObject>();


    public void SelectCationFromDropdown()
    {
        if (CationSelectorDropdown.value == 0)
        { return; }

        else
        {
            
            print("Cation selected = " + CationSelectorDropdown.value);
            CationsToEnable[CationSelectorDropdown.value].SetActive(true);

            //CationSelectorDropdown.interactable = false;
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
