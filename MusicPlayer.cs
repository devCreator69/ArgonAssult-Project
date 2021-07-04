using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{
    void Awake()
    {
        //if there is already one music player no more are allowed to spawn
        int numMusicPlayers = FindObjectsOfType<MusicPlayer>().Length;
        if(numMusicPlayers > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            //Stops music from restarting everytime level reloads
            DontDestroyOnLoad(gameObject);
        } 
        
    }
}
