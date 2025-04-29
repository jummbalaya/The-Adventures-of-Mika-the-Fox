using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // This script is attached to the damage dealer object in the game.
    // This stat is the ammount of damage the object can deal.
    [SerializeField] private int damage = 10; 

    public int DoDamage(int health)
    {
        // This method is called to deal damage to the player.
        // It takes the player's health as a parameter and returns the damage value.
        // The damage value is subtracted from the player's health.
        return health - damage;
    }
}
