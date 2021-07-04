using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUIT GAME!");
        // wont happen inside unity editor so debug statement added to test functionality
    }
    
}
