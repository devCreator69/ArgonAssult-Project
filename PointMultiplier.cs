using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PointMultiplier : MonoBehaviour 
{
   [SerializeField]  int bonusPoints;
   [SerializeField]  AudioSource bonusPointsSound;
   GameObject bonusPointsObject;
   protected ScoreBoard scoreBoard;
   public GameObject ui;
   public float timeUntilDestroyed = 1f;
   public float currentTime = 0;
   
   private void Start() 
   {
       ui.SetActive(false);
       scoreBoard = FindObjectOfType<ScoreBoard>();  
   }
   void AddBonusPoints()
   { 
        scoreBoard.ModifyScore(bonusPoints);
        bonusPointsSound.Play();
   }
   void OnTriggerEnter (Collider other)
   {
       if (other.gameObject.tag == "Multiplier")
       {
           ui.SetActive(true);
           AddBonusPoints();
       }
   }

   //Allows for +100 UI to be diplayed for a set amount of time
    void OnTriggerExit()
    {
     currentTime += Time.deltaTime;
        
        if (currentTime > timeUntilDestroyed)
        {
           ui.SetActive(false);
            currentTime = 0;
        }
      StartCo();
      TemporarilyDeactivate();
    }
    public void StartCo()
    {
       StartCoroutine(TemporarilyDeactivate());
    }
    private IEnumerator TemporarilyDeactivate() 
    {
       yield return new WaitForSeconds(1f);
        ui.SetActive(false);
    }
}

