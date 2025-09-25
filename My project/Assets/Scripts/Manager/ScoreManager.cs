using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;                       // Singleton Pattern
    [SerializeField] private int score;                        // Current score
    [SerializeField] private TextMeshProUGUI scoreText;        // Text component to display the score
    [SerializeField] private TextMeshProUGUI highScoreText;     // Text component to display the high score

    void Awake()
    {
        // Ensure only one instance of ScoreManager exists
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
    }

    void Start()
    {
        scoreText.text = "Score: " + score.ToString(); // Initialize score display
        highScoreText.text = "High Score: " + HighScoreManager.instance.GetHighScore(); // Display high score
    }

    void Update()
    {
        // Update the score display
        scoreText.text = "Score: " + score.ToString();
    }

    //Method to add points to the score
    public void AddScore(int points)
    { 
        score += points;                 // Increase score by the given points

        if(score > HighScoreManager.instance.GetHighScore())
        {
            PlayerPrefs.SetInt("HighScore", score); // Update high score if current score exceeds it
            highScoreText.text = "HighScore: " + score; // Update high score display
        }
    }
}
