using UnityEngine;
using System.Collections;

public class FireTrap : MonoBehaviour
{
    [SerializeField] private int damageAmount = 10;          // Amount of damage to inflict
    [SerializeField] private float activationDelay = 0.5f;    //When player enters trap in how many seconds trap will activate
    [SerializeField] private float activeDuration = 1.5f;     //How long trap will be active
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private PlayerMovement playerMovement;                    // Reference to the PlayerMovement script
    bool isActive = false;                                    //when the trap is active and hurt the player
    bool triggered = false;                                    // when the trap is triggered

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        spriteRenderer.enabled = false; // Initially hide the trap
        playerMovement = FindObjectOfType<PlayerMovement>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(!triggered)
            {
                
                StartCoroutine(ActivateTrap());
            }

            if(isActive)
            {
                playerMovement.health -= damageAmount;
                CameraShake.instance.Shake(4f,1f);
            }
        }
    }

    IEnumerator ActivateTrap()
    {
        triggered = true;

        yield return new WaitForSeconds(activationDelay);
        spriteRenderer.enabled = true; // Show the trap
        isActive = true;
        animator.SetBool("activated",true); // Play activation animation
        yield return new WaitForSeconds(activeDuration);
        isActive = false;
        spriteRenderer.enabled = false; // Hide the trap
        triggered = false;
        animator.SetBool("activated",false); // Reset animation state
    }
}
