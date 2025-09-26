using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    [SerializeField] private int damageAmount = 5; // Amount of damage to inflict
    private PlayerMovement playerMovement; // Reference to the PlayerMovement script

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            if(playerMovement != null)
            {
                playerMovement.health -= damageAmount;
                
                if (playerMovement.health <= 0)
                {
                   GameManager.instance.gameOver();
                    Debug.Log("Player has died!");
                }
            }
        }
    }
}
