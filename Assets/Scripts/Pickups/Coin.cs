using UnityEngine;

public class Coin : Pickup
{
    protected override void OnPickup()
    {
        // Collects coin and logs a message.
        Debug.Log("Coin collected!");
    }
}
