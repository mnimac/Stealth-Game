using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUI : MonoBehaviour
{   
    public GameObject gameLoseUI;
    public GameObject gameWonUI;   
    public GameObject raiseTheAlarm;

    bool gameOver;

    void Start()
    {
        Guard.OnGuardHasSpottedPlayer += showGameLoseUI;

        FindObjectOfType<Player> ().OnReachedEnd += showGameWonUI;
    }

    void Update()
    {
        if (gameOver){
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(0);
            }
        }
        
        if (Input.GetKeyDown(KeyCode.Escape))
        Application.Quit();
    }

    IEnumerator FlickeringAlarm(){     
        while(gameOver){
            raiseTheAlarm.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            raiseTheAlarm.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }                
    }

    void showGameLoseUI(){
        OnGameOver(gameLoseUI);
        StartCoroutine("FlickeringAlarm");
    }

    void showGameWonUI(){
        OnGameOver(gameWonUI);
    }

    void OnGameOver(GameObject gameOverUI) {
        gameOverUI.SetActive(true);
        gameOver = true;
        Guard.OnGuardHasSpottedPlayer -= showGameLoseUI;
        FindObjectOfType<Player> ().OnReachedEnd -= showGameWonUI;
    }
}