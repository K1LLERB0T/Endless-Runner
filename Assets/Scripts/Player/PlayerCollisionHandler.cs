using UnityEngine;

/// <summary>
/// Manages player collisions with obstacles and triggers "Stumble" animation.
/// </summary>
public class PlayerCollisionHandler : MonoBehaviour
{
    // Controls player animation
    [SerializeField] Animator animator;

    // Delay between consecutive collisions
    [SerializeField] float collisionCooldown = 1f;

    // Animator trigger name
    const string hitString = "Stumble";

    float cooldownTimer = 0f;

    void Update()
    {
        cooldownTimer += Time.deltaTime;
    }

    // Manages collision events
    void OnCollisionEnter(Collision collision)
    {
        // Prevents animation play during cooldown
        if (cooldownTimer < collisionCooldown)
            return;

        // Triggers "Stumble" animation
        animator.SetTrigger(hitString);
        cooldownTimer = 0f;
    }
}
