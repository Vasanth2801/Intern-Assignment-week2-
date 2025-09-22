using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;              // moving Speed of the player

    [Header("References Settings")]
    [SerializeField] private Rigidbody2D rb;                     // Reference to the Rigidbody2D component
    Vector2 movement;                                           // movement vector for x and y axis
    PlayerController playerController;                          //Reference to the input action we have created 


    // Called before the first frame of the game
    private void Awake()
    {
        playerController = new PlayerController();                      //Initialize the player controller
        MovementCalling();                                               //Method to handle the movement input actions
    }

    //Method to handle movement input actions we have created in the input action
    void MovementCalling()
    {
        playerController.Player.Move.performed += ctx => movement = ctx.ReadValue<Vector2>();     //when the action is performed, we read the value of the movement vector
        playerController.Player.Move.canceled += ctx => movement = Vector2.zero;                  //when the action is canceled, we set the movement vector to zero
    }

    //Enabling the player controller when the script is enabled
    void OnEnable()
    {
        playerController.Enable();                                     //Enable the player controller
    }

    //Disabling the player controller when the script is disabled
    void OnDisable()
    {
        playerController.Disable();                                    //Disable the player controller
    }

    //It is called at fixed interval and used for physics calculations
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);   // Move the player based on the movement vector and speed
    }
}
