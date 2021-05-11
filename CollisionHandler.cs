using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{ 
    [SerializeField] float loadDelay = 1f;
    [SerializeField] ParticleSystem Explosion;
    [SerializeField] int playerLivesNumber = 3;
    [SerializeField] int playerLivesDecrease = 1;
     //[SerializeField] int noLives = 0; ////

    PlayerLives playerLivesScript;

    PlayerController playerController; 
    
    

    void Start() 
    {
        playerLivesScript = FindObjectOfType<PlayerLives>();
        playerController = FindObjectOfType<PlayerController>(); 
    }
    void OnTriggerEnter(Collider other) 
    {
        DecreaseLives();
        if(playerLivesNumber < 1)
        {  
        CrashSequence();   
        }
        Debug.Log(this.name + " --Collided with-- " + other.gameObject.name);
    }
    void DecreaseLives ()
    {
        playerLivesNumber = playerLivesNumber - 1;
        playerLivesScript.ModifyLives(playerLivesDecrease);
       // if(playerLivesNumber == 0);///
      //  {
      
        //    playerLivesScript.Start(text = noLives.ToString()); ///
        //}
    }
        
    void CrashSequence()
    {   
        Explosion.Play();
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        playerController.SetLasersActive(false); 
        // turn shoot off during the load time delay
        playerController.SetExhaustFlamesActive(false);
        Invoke("ReloadLevel", loadDelay);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
