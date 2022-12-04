using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseButton : MonoBehaviour  //THIS IS SAI'S SCRIPT USED TO CHOOSE SALT-INSTANTIATION BUTTONS IN IONIC REACTION SIMULATOR
{/*
    // Every button in saltDropdown must be named as "[salt name]Button" (e.g. "CuSO4Button")
    // The text of every button must be "[salt name]"
    private Dropdown saltDropdown;

    [Header("Do not modify Salt Buttons")]
    [SerializeField]
    private List<GameObject> saltButtons;

    [Header("Do not modify Button Images")]
    [SerializeField]
    private List<Sprite> buttonImages;

    [SerializeField]
    private List<bool> buttonEnabled;

    [SerializeField]
    private List<string> buttonText;

    //[Header("Explanation Display")]
    //[SerializeField]
    //private ExplanationDialogController explanationDisplay;

    [Header("Peer")]
    [SerializeField]
    private GameObject peer;

    private void Start()
    {
        saltDropdown = GetComponent<Dropdown>();
        //saltDropdown.ClearOptions();

        //Dropdown.OptionData initialOption = new Dropdown.OptionData();
        //initialOption.text = "Choose a Salt";

        //saltDropdown.options.Add(initialOption);

        foreach (GameObject button in saltButtons)
        {
            int buttonIndex = saltButtons.IndexOf(button);
            if (buttonEnabled[buttonIndex])
            {
                Dropdown.OptionData option = new Dropdown.OptionData();
                // Display the salt sprite image if it has been provided
                if (buttonImages[buttonIndex] != null)
                {
                    option.image = buttonImages[buttonIndex];
                }
                option.text = buttonText[buttonIndex];
                saltDropdown.options.Add(option);
            }
        }

        saltDropdown.RefreshShownValue();
    }

    public void ValueChangedHandler()
    {
        // value will be 0 if the "Choose a Salt" default selection has been chosen
        if (saltDropdown.value != 0)
        {
            string buttonName = saltDropdown.options[saltDropdown.value].text + "Button";
            foreach (GameObject button in saltButtons)
            {
                if (button.name == buttonName)
                {
                    //if (button.name != FindElementDisplayedByPeer())
                    //{
                    //    explanationDisplay.SetTextWrapper(saltDropdown.options[saltDropdown.value].text);
                    //    button.SetActive(true);
                    //    gameObject.SetActive(false);
                    //}
                    //else
                    //{
                    //    explanationDisplay.NoButtonReplication();
                    //    saltDropdown.value = 0;
                    //}
                    //explanationDisplay.SetTextWrapper(saltDropdown.options[saltDropdown.value].text);
                    button.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
        }
    }

    private string FindElementDisplayedByPeer()
    {
        GameObject buttonsParent = peer.transform.GetChild(1).gameObject;
        for (int i = 0; i < 8; i++)
        {
            if (buttonsParent.transform.GetChild(i).gameObject.activeSelf)
            {
                return buttonsParent.transform.GetChild(i).gameObject.name;
            }
        }
        return "";
    }*/
}
