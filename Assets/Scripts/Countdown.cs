using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public Text countdownDisplay;

    public int countdownTime = 3;

    void Start(){
        //PauseGame();
        StartCoroutine(CountdownTheGame());
    }

    IEnumerator CountdownTheGame(){
        while(countdownTime > 0){
            countdownDisplay.text = countdownTime.ToString(); 
            yield return new WaitForSeconds(1f);
            countdownTime--;
        }
        countdownDisplay.text = "GO!";
        
        ResumeGame();
        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }

    void PauseGame (){
        Time.timeScale = 0f;
    }

    void ResumeGame (){
        Time.timeScale = 1f;
    }
}
