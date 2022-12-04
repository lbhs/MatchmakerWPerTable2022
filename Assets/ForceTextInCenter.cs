using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceTextInCenter : MonoBehaviour
{
    [SerializeField]
    private Image imageOfSalt;

    // Start is called before the first frame update
    void Start()
    {
        LeftOrRightJustifyText();
    }

    private void LeftOrRightJustifyText()
    {
        if (imageOfSalt.sprite == null)
        {
            GetComponent<Text>().alignment = TextAnchor.MiddleCenter;
        }
        else
        {
            GetComponent<Text>().alignment = TextAnchor.MiddleLeft;
        }
    }
}
