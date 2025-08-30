using UnityEngine;

/// <summary>
/// An abstract base class for all collectible items.
/// </summary>
public abstract class Pickup : MonoBehaviour
{
    // Collectible rotation speed
    [SerializeField] float rotationSpeed = 100f;

    // Tag used to identify the player
    const string playerString = "Player";

    // Rotates with each frame.
    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);
    }

    // Called when another collider enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        // Checks if player picked up the item and removes it.
        if (other.CompareTag(playerString))
        {
            OnPickup();
            Destroy(gameObject);
        }
    }

    // To be implemented by child classes to define pickup effect.
    protected abstract void OnPickup();
}
