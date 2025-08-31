using UnityEngine;

/// <summary>
/// Handles the behavior of a collectible power-up.
/// </summary>
public class PowerUp : Pickup
{
    // Adjust the level's move speed.
    [SerializeField] float adjustChangeMoveSpeedAmount = 3f;

    LevelGenerator levelGenerator;

    // Initializes the power-up referencing the LevelGenerator.
    public void Init(LevelGenerator levelGenerator)
    {
        this.levelGenerator = levelGenerator;
    }

    // Called when power-up is picked up by player.
    protected override void OnPickup()
    {
        // Calls the method to change the level's chunk speed.
        levelGenerator.ChangeChunkSpeed(adjustChangeMoveSpeedAmount);
    }
}
