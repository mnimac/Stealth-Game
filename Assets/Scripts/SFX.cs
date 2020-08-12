using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    public AudioSource Win;
    public AudioSource Lose;

    public void PlayWin(){
        Win.Play();
    }
    
    public void PlayLose(){
        Lose.Play();
    }
}
