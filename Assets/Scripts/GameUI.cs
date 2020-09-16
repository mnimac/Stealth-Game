using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{   
    public GameObject gameLoseUI;
    public GameObject gameWonUI;   
    public GameObject raiseTheAlarm;
    public GameObject scoreBox;
    public Text timeBox, bestTimeBox;
    
    public float timeStart;
    public static float highScore;

    public static int i = 0;

    bool gameOver;

    void Start()
    {
        Guard.OnGuardHasSpottedPlayer += showGameLoseUI;

        FindObjectOfType<Player> ().OnReachedEnd += showGameWonUI;

        timeBox.text = timeStart.ToString("F2");
    }
 
    void Update()
    {
        if (gameOver){
            if (Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(0);
                Scoring.coinScore = 0;                           
            }                      
        }

        if(!gameOver){
            timeStart += Time.deltaTime;
            timeBox.text = timeStart.ToString("F2");
        }
    }

    IEnumerator FlickeringAlarm(){     
        while(gameOver){
            raiseTheAlarm.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            raiseTheAlarm.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }                
    }

    void BestTime(){    
        while (i!=1){
            highScore = timeStart;
            i++;
        } 
    
        if(highScore > timeStart){        
            highScore = timeStart;
        }

        bestTimeBox.text = highScore.ToString("F2") + " is THE best time.";
        scoreBox.SetActive(true);
    }

    void showGameLoseUI(){
        OnGameOver(gameLoseUI);
        StartCoroutine("FlickeringAlarm");
    }

    void showGameWonUI(){
        OnGameOver(gameWonUI);
        BestTime();
    }

    void OnGameOver(GameObject gameOverUI) {
        gameOverUI.SetActive(true);
        gameOver = true;
        Guard.OnGuardHasSpottedPlayer -= showGameLoseUI;
        FindObjectOfType<Player> ().OnReachedEnd -= showGameWonUI;
    }
}