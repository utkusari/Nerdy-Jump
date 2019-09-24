using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deadzone : MonoBehaviour
{

    public GameObject gameOverPanel;
    public Text finalScore;
    public Text score;
    
    void OnCollisionEnter2D(Collision2D collision){
        Time.timeScale = 0.0f;
        gameOverPanel.SetActive(true);
        finalScore.text = score.text;
    }

}
