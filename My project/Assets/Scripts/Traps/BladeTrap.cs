using Unity.Cinemachine;
using UnityEngine;

public class BladeTrap : MonoBehaviour
{
    [SerializeField] private float roatationSpeed = 100f;                        // Speed of blade rotation
    [SerializeField] float damageAmount = 100f;                                   // Amount of damage inflict to player
    private PlayerMovement playerMovement;               // Reference to the PlayerMovement script
    

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();                       // Find and reference the PlayerMovement script
    }


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, roatationSpeed * Time.deltaTime);       // ROtate the blade continuously
    }
  
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            playerMovement.health -= damageAmount;                                   // Inflict damage to the player on collision
            GameManager.instance.gameOver();                                      // Trigger game over in GameManager
        }
    }
}
