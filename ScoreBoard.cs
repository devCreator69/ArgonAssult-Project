using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//necessary to access TextMeshPro for UI

public class ScoreBoard : CollisionHandler
{
    protected int score;
    
    //Public is used instaed of private so that one class can influence another
    //We need Ememy to influence scoreboard
    protected TMP_Text scoreText;
    void Start() 
    {
        scoreText = GetComponent<TMP_Text>();
    }
    
    public void ModifyScore (int amontToIncrease)
    { 
        score += amontToIncrease;
        scoreText.text = score.ToString();
        //Debug.Log(score);
         
    } 
  
}


