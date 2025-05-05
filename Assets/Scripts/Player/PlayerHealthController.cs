using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    [Header("Misc Settings")]
    [SerializeField] private float InvincibilityDuration = 1f; // Duration of invincibility after taking damage
    [SerializeField] private float cherryHPBoost = 5f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isInvincible = false; // Flag to check if the player is invincible

    void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        float pickUpDestroyDelay = 0.4f; 
        int deathDelay = 1; // Delay before destroying the player object

        // Check if the player is invincible, if so, ignore the collision
        if (isInvincible) return;

        if (other.CompareTag("Damage"))
        {
            // If the player collides with a damage dealer object, deal damage to the player.
            DamageDealer damageDealer = other.GetComponent<DamageDealer>();

            if (Player.Instance != null && damageDealer != null)
            {
                Player.Instance.Health = damageDealer.DoDamage(Player.Instance.Health);
                GetComponent<KnocbackEffect>().Knockback();
                animator.SetBool("takeDamage", true);
                spriteRenderer.color = new Color(1f, 0f, 0f, 0.6f);
                isInvincible = true;
                StartCoroutine(WaitAndAnim(InvincibilityDuration));

                Debug.Log("Player Health: " + Player.Instance.Health);

                if (Player.Instance.Health <= 0)
                {
                    Destroy(gameObject, deathDelay); // Destroy the player object after the delay
                    LevelManager.Instance.RespawnPlayer(); // Call the respawn method from LevelManager
                }
            }
        }

        if (other.CompareTag("PickUpCherry"))
        {
            // If the player collides with a cherry, increase the player's health.
            if (Player.Instance.MaxHealth == Player.Instance.Health) return;

            if (Player.Instance.MaxHealth > Player.Instance.Health)
            {
                Player.Instance.Health += (int)cherryHPBoost;
                if (Player.Instance.Health > Player.Instance.MaxHealth)
                {
                    Player.Instance.Health = Player.Instance.MaxHealth; 
                }
                other.GetComponent<Animator>().SetTrigger("collected");
                Destroy(other.gameObject, pickUpDestroyDelay); 
            }
        }

        if (other.CompareTag("PickUpJem"))
        {
            // If the player collides with a jem, increase the player's collected jems count.
            Player.Instance.JemsCollected++;
            other.GetComponent<Animator>().SetTrigger("collected");
            Destroy(other.gameObject, pickUpDestroyDelay); 
        }
    }

    private IEnumerator WaitAndAnim(float animDelay)
    {
        // Wait for the animation to finish before resetting the takeDamage trigger
        yield return new WaitForSeconds(animDelay); // Adjust the delay as needed
        animator.SetBool("takeDamage", false);
        isInvincible = false;
        spriteRenderer.color = new Color(1f, 1f, 1f, 1f); // Reset the color to white
        yield return null; // Ensure the coroutine ends properly
    }
}
