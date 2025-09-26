using UnityEngine;

public class Powerups : MonoBehaviour
{
    private PlayerMovement playerMovement; // Reference to the PlayerMovement script

    void Start()
    {
        // Find the PlayerMovement script in the scene
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
           if(playerMovement != null)
            {
                playerMovement.health += 20; // Increase player's health by 20
            }

           if(playerMovement.health > 100)
            {
                playerMovement.health = 100; // Cap health at 100
            }

                // Destroy the power-up object after collection
                Destroy(gameObject);
        }
    }
}
