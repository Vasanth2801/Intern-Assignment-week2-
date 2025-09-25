using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;      //static instance of the GameManager class

    void Awake()
    {
        if (instance == null)                 //if the instance is null
        {
            instance = this;                  //set the instance to this
            DontDestroyOnLoad(gameObject);   //do not destroy the game object on load
        }
        else if (instance != this)            //else if the instance is not this
        {
            Destroy(gameObject);              //destroy the game object
        }
    }
    
    

   

    public void Restart()
    {
        SceneManager.LoadScene(1);           // Load the Game scene
        Time.timeScale = 1f;              //set the time scale to 1f
    }

    public void QuitGame()
    {
        Debug.Log("Quit button clicked"); // Log message to indicate the button was clicked
        Application.Quit();               //quit the application
    }

    public void PlayButton()
    {
          SceneManager.LoadScene(1);       // Load the Game scene
    }
}