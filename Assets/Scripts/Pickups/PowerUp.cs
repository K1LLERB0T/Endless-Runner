using UnityEngine;

public class PowerUp : Pickup
{
    protected override void OnPickup()
    {
        // Collects power-up and logs a message.
        Debug.Log("Power Up!");
    }
}
