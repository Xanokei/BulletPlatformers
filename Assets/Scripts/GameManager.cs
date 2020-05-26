using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{
    private bool gameHasEnded = false;

    public float restartDelay = 1f;

    public GameObject completeLevelUI;

    public GameObject gameOverObj;
    private GameOver gameOverUI;

    private void Start()
    {
        gameOverUI = gameOverObj.GetComponent<GameOver>();
    }

    public void CompleteLevel () 
    {
        completeLevelUI.SetActive(true);
    }

    public void GameOver() {
        gameHasEnded = true;
        Debug.Log("GAME OVER");

        gameOverUI.GameLoseScreen();
        //Invoke("Restart", restartDelay);
        //Restart();
    }

    public void GameWin()
    {
        gameOverUI.GameWinScreen();
    }

    public void Restart (){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void NextLevel()
    {
        //Debug.Log("Build Settings Count: " + SceneManager.sceneCountInBuildSettings);
        //Debug.Log("Index Count: " + SceneManager.GetActiveScene().buildIndex);
        //+1 because BUILD INDEX starts at 0 and SCENE COUNT starts at 1
        if ((SceneManager.GetActiveScene().buildIndex +1) < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        } else
        {
            ToMainMenu();
        }
        
    }


}


