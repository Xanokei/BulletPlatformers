using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameObject gameLoseUI;
    public GameObject gameWinUI;
    // Update is called once per frame
    void Update()
    {

    }

    public void GameLoseScreen()
    {
        gameLoseUI.SetActive(true);
    }
    public void GameWinScreen()
    {
        gameWinUI.SetActive(true);
    }

    //public void QuitGame()
    //{
    //    Debug.Log("Quit to menu");
    //}
    //public void Restart()
    //{
    //    Debug.Log("Restart level");
    //}
}
