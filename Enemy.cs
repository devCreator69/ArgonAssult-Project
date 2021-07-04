using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject deathFX;
    //Created area to drag in enemy explosion
    [SerializeField] GameObject hitVFX;
    [SerializeField] protected int scorePerHit;
    [SerializeField] int killScore;
    [SerializeField] int hitPoints;
    GameObject parentGameObject;
    protected ScoreBoard scoreBoard;
    protected Rigidbody rb;

    protected void SetScorePerHitValue()
    {
        scorePerHit = 4;
    }
    void Start() 
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
        //FindObjectOfType looks through entire project and finds first ScoreBoard 
        //Can safely use bc i only have one script named ScoreBoard
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
        AddRigidbody();
    }
    void AddRigidbody()
    // adding in code so that it is automatically applied to all enemies instead
    //of individually adding components
    {
      
        rb = gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    void OnParticleCollision(GameObject other) 
    {
        ProcessHit();
        if(hitPoints < 1)
        {
            KillEnemy();
        }
    }
    void ProcessHit()
    {
        GameObject hitSparks = Instantiate(hitVFX, transform.position, Quaternion.identity);
        hitSparks.transform.parent = parentGameObject.transform;
        
        hitPoints = hitPoints - 1;
        //Could also be written as hitPoints--
        scoreBoard.ModifyScore(scorePerHit);
    }
    public void KillEnemy()
    {
       scoreBoard.ModifyScore(killScore);
       GameObject explosion = Instantiate(deathFX, transform.position, Quaternion.identity);
       //Instantiate asks for the object we want to use(deathVFX), the postion we want it to appear in
       //which is where the enemy is - (transform.position), and the proper rotation(Quaternion.identity)
       //.identity means no rotation
       explosion.transform.parent = parentGameObject.transform;
       //without this line all explosions that occur stay visible in the hierarchy 
       //now all explosions are stored in the parent Spawn at Runtime
       Destroy(gameObject);
    }


}
