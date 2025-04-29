using UnityEngine;

public class KnocbackEffect : MonoBehaviour
{
    [SerializeField] private float knockbackForce = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Knockback()
    {
        // Check the player's facing direction and apply knockback
        if (GetComponent<PlayerController>().IsFacingRight)
        {
            rb.linearVelocity = new Vector2(-knockbackForce, rb.linearVelocity.y); // Knockback to the left
            print("Knockback to the left");
        }
        else
        {
            rb.linearVelocity = new Vector2(knockbackForce, rb.linearVelocity.y); // Knockback to the right
            print("Knockback to the right");
        }
    }
}
