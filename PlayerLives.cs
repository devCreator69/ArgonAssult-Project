using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerLives : MonoBehaviour
{
   [SerializeField] int lives = 3;
     TMP_Text livesText;
    public void Start()
    {
        livesText = GetComponent<TMP_Text>();
        livesText.text = lives.ToString();
    }
    public void ModifyLives(int amountToDecrease)
    {
        lives = lives - amountToDecrease;
        livesText.text = lives.ToString();
    }
}
