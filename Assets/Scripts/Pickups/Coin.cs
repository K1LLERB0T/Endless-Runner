using UnityEngine;
/// <summary>
/// Handles the behavior of a collectible coin pickup.
/// </summary>
public class Coin : Pickup
{
    // Score to add when the coin is picked up.
    [SerializeField] int scoreAmount = 100;
    ScoreManager scoreManager;

    // Initializes the coin referencing the ScoreManager.
    public void Init(ScoreManager scoreManager)
    {
        this.scoreManager = scoreManager;
    }

    // Called when coin is picked up by player.
    protected override void OnPickup()
    {
        // Increases score by the specified amount.
        scoreManager.IncreaseScore(scoreAmount);
    }
}
