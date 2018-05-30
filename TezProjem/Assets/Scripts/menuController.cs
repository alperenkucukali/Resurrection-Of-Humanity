using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuController : MonoBehaviour {

    public void playGame()
    {
        SceneManager.LoadScene("Sahnem");
    }
    public void exitGame()
    {
        Application.Quit(); 
    }
    public void optionsGame()
    {
        SceneManager.LoadScene("Options");
    }
}
