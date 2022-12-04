using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonScript : MonoBehaviour
{
    public string ButtonChoice;



    public void SendAnswerToBeChecked()
    {
        GameObject.Find("AnswerManagementSystem").GetComponent<AnswerKeyScript>().CheckAnswer(ButtonChoice);
    }
    
    private void OnEnable()
    {
        GetComponent<Button>().interactable = true;
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
