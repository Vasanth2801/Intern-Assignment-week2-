using UnityEngine;

public class collectable : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(10); // Add 10 points to the score
            Destroy(gameObject); // Destroy the collectable object
        }
    }
}
