using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceAspectRatio : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().preserveAspect = true;
    }



}
