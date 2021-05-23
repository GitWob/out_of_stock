using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject Main_Menu;
    public GameObject credits;

    void Start()
    {
        credits.SetActive(false);
    }

    public void playGame()
    {
        SceneManager.LoadScene("Level 1");
    } 

    public void Credits()
    {
        Main_Menu.SetActive(false);
        credits.SetActive(true);
    } 

    public void back()
    {
        Main_Menu.SetActive(true);
        credits.SetActive(false);
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
