using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public GameObject player; // Reference to the player object
    public float speed = 2.0f; // Speed of the enemy


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
}
