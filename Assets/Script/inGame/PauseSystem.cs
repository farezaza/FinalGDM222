using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject EndMenu;
    public GameObject PauseButton;
    public static bool isPause;
    public CountdownTimer countdownTimer;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        EndMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!countdownTimer.timeOut)
        {
            //pause game
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if(isPause)
                {
                    ContinueGame();
                }
                else
                {
                    PauseGame();
                }
            }
        }
        
        //game ends
        if (countdownTimer.timeOut == true)
        {
            PauseButton.SetActive(false);
            Time.timeScale = 0f;
            EndMenu.SetActive(true);
        }
        
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void ContinueGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
