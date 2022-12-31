using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrivalentIonScript : MonoBehaviour
{
    public int BondingSitesRemaining;  //initially set this to 3

    // Start is called before the first frame update
    void Start()
    {
        BondingSitesRemaining = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FillABondingSite()
    {
        BondingSitesRemaining--;
        //print(BondingSitesRemaining + " sites left open");
    }
}
