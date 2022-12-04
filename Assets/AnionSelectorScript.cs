using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class IonOptions
{
    public List<GameObject> IonsToEnable = new List<GameObject>();  //sublist of individual ions in each choice from the master list
}

public class AnionSelectorScript : MonoBehaviour
{
    public Dropdown AnionSelector;
    public List<IonOptions> AnionList = new List<IonOptions>();  //master list
    public List<GameObject> ImagesForAnions = new List<GameObject>();
    public List<GameObject> PrefabsToInstantiate = new List<GameObject>();
     

    // Start is called before the first frame update
    
    public void SelectAnionFromDropdown()
    {
        if (AnionSelector.value == 0)
        {
            return;
        }

        else
        {
            //disable all the ion choices here, then activate the ONE that student has chosen.  OR use IonsToDisable. . .
            foreach (var item in AnionList[AnionSelector.value].IonsToEnable)
            {
                item.SetActive(true);
            }
            //AnionSelector.interactable = false;
        }

    }
    

}
