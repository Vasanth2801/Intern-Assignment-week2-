using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUi : MonoBehaviour
{
    public GameObject pausemenuUI;           //Gameobject for the pause menu UI
    bool isGamePaused = false;                      //boolean to check if the game is paused


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))  //checking if the escape key is pressed
        {
            if (isGamePaused)                  //if the game is paused
            {
                Resume();                      //call the resume method
            }
            else
            {
                Pause();                       //else call the pause method
            }
        }
    }


    public void Resume()
    {
        pausemenuUI.SetActive(false);         //set the pause menu UI to false
        Time.timeScale = 1f;                  //set the time scale to 1f
        isGamePaused = false;     //set the boolean to false
    }

    public void Pause()
    {
        pausemenuUI.SetActive(true);          //set the pause menu UI to true
        Time.timeScale = 0f;                  //set the time scale to 0f
        isGamePaused = true;      //set the boolean to true
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);           // Load the Main Menu scene
    }

}
