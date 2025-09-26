using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public float speed = 2.0f; // Speed of the enemy
    public float damage = 10f; // Damage to the player on collision

    private EnemySpawner enemySpawner;
    private PlayerMovement playerMovement;
   


    void Awake()
    {
        enemySpawner = FindObjectOfType<EnemySpawner>();
        playerMovement = FindObjectOfType<PlayerMovement>();
    }


    void Start()
    {
        // Find the player object by tag if not assigned
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction towards the player
            Vector3 direction = (player.transform.position - transform.position).normalized;
            // Move the enemy towards the player
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(other.gameObject); // Destroy the enemy on collision
            Debug.Log("Enemy hit!");
            gameObject.SetActive(false);          // Deactivate the bullet on collision

            enemySpawner.waves[enemySpawner.currentWave].enemiesCount--;
        }

        if(other.CompareTag("Player"))
        {
            playerMovement.health -= damage; // Reduce player's health on collision
            CameraShake.instance.Shake(4f,0.5f);
            if (playerMovement.health <= 0)
            {
                playerMovement.health = 0;
                Debug.Log("Player Dead!");
                GameManager.instance.gameOver();
            }
        }
    }
}
