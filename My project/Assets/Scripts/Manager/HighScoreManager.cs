using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    public static HighScoreManager instance;         //Singleton Pattern

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);           //Persisting the object across scenes
        }
        else
        {
            Destroy(gameObject);                      //Destroying duplicate instances
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);   //Getting the high score from PlayerPrefs, default is 0
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();          
        PlayerPrefs.Save();                           //Saving the changes to PlayerPrefs
        Debug.Log("High Score Reset!");          //Debugging message to indicate high score has been reset
    }
}
