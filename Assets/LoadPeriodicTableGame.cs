using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPeriodicTableGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartPeriodicTableGame()
    {
        SceneManager.LoadScene(2);
    }

    public void LoadVideoIntro()
    {
        SceneManager.LoadScene(1);
    }
}
