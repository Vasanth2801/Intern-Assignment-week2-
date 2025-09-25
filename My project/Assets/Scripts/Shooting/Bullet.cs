using UnityEngine;

public class Bullet : MonoBehaviour
{
   [SerializeField] private float speed = 20f; // Speed of the bullet
   [SerializeField] private float lifeTime = 2f; // Lifetime of the bullet in seconds
   private float lifeTimer; // Timer to track the lifetime of the bullet
    private Rigidbody2D rb;    // Reference to the Rigidbody2D component

    // Called before the first frame of the game
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the Rigidbody2D component
    }

    // Called when the bullet is enabled
    void OnEnable()
    {
        lifeTimer = lifeTime; // Reset the timer when the bullet is enabled
        if(rb != null)
        {
            rb.linearVelocity = transform.right * speed; // Set the velocity of the bullet
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifeTimer -= Time.deltaTime; // Decrease the timer
        if (lifeTimer <= 0f)
        {
            gameObject.SetActive(false); // Deactivate the bullet when its lifetime is over
        }
    }
}
