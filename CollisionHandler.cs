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
    //[SerializeField] int scoreToAdvance;
    PlayerLives playerLivesScript;
    PlayerController playerController;
    [SerializeField] int gemCount;
    [SerializeField] AudioSource playerExplosionSound;
    [SerializeField] AudioSource looseLifeSound;
    public GameObject ui;

   public float timeUntilDestroyed = 2f;
   public float currentTime = 0;


     void Start() 
    {
        playerLivesScript = FindObjectOfType<PlayerLives>();
        playerController = FindObjectOfType<PlayerController>();  

        ui.SetActive(false);
    }
     void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Untagged")  
        {
            DecreaseLives();
            if(playerLivesNumber < 1)
            {  
             CrashSequence();   
            }
        }
        // Must collect X amount of gems to save animals
        if(other.gameObject.tag == "Multiplier")
        {
            Debug.Log("This is gem count " + gemCount);
            gemCount++;
            other.gameObject.SetActive(false);
            //gemCount++;
        }

        if(other.gameObject.tag == "Finish" && gemCount > 9)
        {
            Invoke("LoadNextLevel" , loadDelay);
        } 
        else if(other.gameObject.tag == "Finish" && gemCount <= 9)
        {
            ui.SetActive(true);
            Invoke("ReloadLevel", loadDelay);
        }
    } 

    void DecreaseLives ()
    {
        looseLifeSound.Play();
        //to make sure score can not be below 0
        playerLivesNumber = playerLivesNumber - 1;

        Debug.Log("Player has " + playerLivesNumber + " lives");
        
        if(playerLivesNumber < 0)
        {
            playerLivesNumber = 0;
        } 
        else
        {
            playerLivesScript.ModifyLives(playerLivesDecrease);
        }
    }
        
    void CrashSequence()
    {   
        Explosion.Play();

        playerExplosionSound.Play();

        GetComponent<AudioSource>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<PlayerController>().enabled = false;
        playerController.SetLasersActive(false); 
        // turn shoot off during the load time delay
        playerController.SetExhaustFlamesActive(false);
        Invoke("ReloadLevel", loadDelay);
    }
     protected void LoadNextLevel() 
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}

