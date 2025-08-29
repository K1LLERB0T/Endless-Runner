using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Controls the movement of player and limits the boundary using clamping.
/// </summary>
public class PlayerController : MonoBehaviour
{
    // Movement configuration
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float xClamp = 4f;
    [SerializeField] float zClamp = 2f;

    // Components
    Rigidbody rb;
    Vector2 movement;

    // Gets rigidbody component and called before script is loaded.
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // For physics calculations, called at every fixed framerate.
    void FixedUpdate()
    {
        HandleMovement();
    }

    // Reads input from the player and stores the vector.
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    // Handles the movement and clamping of the player.
    void HandleMovement()
    {
        // Calculates the target position based on input and move speed.
        Vector3 currentPosition = rb.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime);

        // Limits/clamps the player boundary.
        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);

        // New position is applied to the rigidbody.
        rb.MovePosition(newPosition);
    }
}
