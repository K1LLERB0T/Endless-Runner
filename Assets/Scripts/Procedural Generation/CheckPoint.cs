using UnityEngine;

/// <summary>
/// Triggers a time extension when the player enters the checkpoint.
/// </summary>
public class CheckPoint : MonoBehaviour
{
    // The amount of time to add to the game clock.
    [SerializeField] float checkPointTimeExtension = 5f;

    GameManager gameManager;

    // The tag used to identify the player GameObject.
    const string playerString = "Player";

    void Start()
    {
        // Finds and stores a reference to the GameManager in the scene.
        gameManager = FindFirstObjectByType<GameManager>();
    }

    // Called when another collider enters the trigger.
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerString))
        {
            // Increases the game time using the GameManager.
            gameManager.IncreaseTime(checkPointTimeExtension);
        }
    }
}
