using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ChooseSceneFromDropdown : MonoBehaviour
{
    public TMP_Dropdown VersionSelect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseScene()
    {
        print(VersionSelect.value);
        SceneManager.LoadScene(VersionSelect.value);   //Scene(1) = CuCl2 + NaOH,  Scene(2) = FeCl3 + NaOH, Scene(3) = CuCl2 + FeCl3, Scene (4) is ??
    }

}
