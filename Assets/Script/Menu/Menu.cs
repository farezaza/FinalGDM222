using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //play button
    public void GoToScreen()
    {
        SceneManager.LoadScene("Ingame");
        PauseSystem.isPause = false;
    }
    //quit game
    public void QuitApp()
    {
        Application.Quit();
        print("Game Quit");
    }
}
