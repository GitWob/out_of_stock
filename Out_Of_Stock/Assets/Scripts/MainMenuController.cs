using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    void Start()
    {

    }
    public void playGame()
    {
        SceneManager.LoadScene("Level 1");
    } 

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    } 

    public void back()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void backToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
