using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool PausedGame = false;
    public GameObject PauseUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(PausedGame) {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Resume(){
        PauseUI.SetActive(false);
        Time.timeScale = 1f;
        PausedGame = false;
    }

    void Pause(){
        PauseUI.SetActive(true);
        Time.timeScale = 0f;
        PausedGame = true;
    }

    public void Quit(){
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
