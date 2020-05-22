using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    // playGame Starts the game
    public void playGame()
    {
        SceneManager.LoadScene("Elevator");
    }

    // Option buttons
    public void options()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void back()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }
    
    // Exits the game
    public void exitGame()
    {
        Application.Quit();
    }
}
