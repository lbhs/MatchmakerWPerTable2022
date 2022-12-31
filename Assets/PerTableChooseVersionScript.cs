using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PerTableChooseVersionScript : MonoBehaviour
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

    public void ChoosePerTableScene()
    {
        print(VersionSelect.value);
        SceneManager.LoadScene(VersionSelect.value);   //Scene(1) = defined sequence of 10 questions;  Scene(2) = random selection of 10 questions
    }
}
