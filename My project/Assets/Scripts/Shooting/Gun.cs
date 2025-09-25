using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform firePoint; // Point from where the bullet is fired
    [SerializeField] private ObjectPoolManager poolManager; // Reference to the ObjectPoolManager for bullet pooling

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // Check if the space key is pressed
        {
            ShootBullet(); // Call the method to shoot a bullet
        }
    }

    void ShootBullet()
    {
        poolManager.SpawnFromPool("Bullet", transform.position, transform.rotation); // Spawn a bullet from the pool at the fire point's position and rotation
        AudioManager.instance.PlayShootingSound(); // Play the shooting sound
    }
}


