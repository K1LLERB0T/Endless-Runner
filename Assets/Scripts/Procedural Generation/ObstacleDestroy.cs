using UnityEngine;

/// <summary>
/// Destroys objects that enter its trigger
/// </summary>
public class ObstacleDestroy : MonoBehaviour
{
    // Destroy on trigger enter
    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
