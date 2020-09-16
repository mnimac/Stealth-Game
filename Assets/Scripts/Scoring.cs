using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Scoring : MonoBehaviour
{
    public GameObject coinText;
    public static int coinScore;
    
    void OnTriggerEnter(Collider col){
        coinScore++;
        coinText.GetComponent<Text>().text = "Coins: " + coinScore; 

    }
}