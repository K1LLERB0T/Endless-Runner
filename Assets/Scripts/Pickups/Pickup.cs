using UnityEngine;

/// <summary>
/// An abstract base class for all collectible items.
/// </summary>
public abstract class Pickup : MonoBehaviour
{
    // Collectible rotation speed
    [SerializeField] float rotationSpeed = 100f;

    AudioSource audioSource;

    // Tag used to identify the player
    const string playerString = "Player";

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

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
            // Play pickup sound
            if (audioSource != null)
            {
                audioSource.PlayOneShot(audioSource.clip);
            }

            OnPickup();
            Destroy(gameObject, 0.5f);
        }
    }

    // To be implemented by child classes to define pickup effect.
    protected abstract void OnPickup();
}
