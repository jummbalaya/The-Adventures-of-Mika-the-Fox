using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Move & Jump Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private int maxJumps = 2;

    [Header("Animation Settings")]
    [SerializeField] Sprite jumpImage;
    [SerializeField] Sprite fallImage;

    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private float horizontal;
    private bool isFacingRight = true;
    private int jumpCount;

    public bool IsFacingRight { get => isFacingRight; set => isFacingRight = value; }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        jumpCount = maxJumps;
    }

    void Update()
    {
        OnMove();

        if (horizontal > 0 && !IsFacingRight)
        {
            Flip();
        }
        else if (horizontal < 0 && IsFacingRight)
        {
            Flip();
        }
    }

    #region PLAYER MOVEMENT
    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && jumpCount > 0)
        {
            // Reset vertical velocity to ensure consistent jump height
            // regardless of the current vertical velocity
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            animator.SetBool("isJumping", IsGrounded());
            animator.SetBool("isFalling", false);
            // Decrease jump count
            jumpCount--;
        }
        if (context.canceled && rb.linearVelocity.y > 0)
        {
            // Reduce jump height if button is released early
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
            animator.SetBool("isJumping", IsGrounded());
            animator.SetBool("isFalling", false);
        }
        if (IsGrounded())
        {
            // Reset jump count when grounded
            jumpCount = maxJumps;
            animator.SetBool("isFalling", IsGrounded());
            animator.SetBool("isFalling", false);
        }
        if (rb.linearVelocity.y < -0.1f)
        {
            animator.SetBool("isFalling", rb.linearVelocity.y < -0.1f);
        }

    }

    private void OnMove()
    {
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, rb.linearVelocity.y);
        animator.SetBool("isRunning", horizontal != 0);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    #endregion
}
