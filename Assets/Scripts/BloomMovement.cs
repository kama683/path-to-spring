using UnityEngine;

public class BloomMovement : MonoBehaviour
{
    private Animator animator;

    [Header("References")]
    public Transform groundCheck;
    public Transform visual;

    [Header("Movement")]
    public float moveSpeed = 5f;
    public float airControlMultiplier = 0.9f;

    [Header("Jump")]
    public float jumpForce = 11f;
    public float groundCheckRadius = 0.12f;
    public LayerMask groundLayer;

    [Header("Jump Feel")]
    public float coyoteTime = 0.12f;
    public float jumpBufferTime = 0.12f;
    public float fallGravityMultiplier = 1.8f;
    public float lowJumpGravityMultiplier = 2.2f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private float moveInput;

    private float coyoteTimeCounter;
    private float jumpBufferCounter;

    private Vector3 visualScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();

        if (visual != null)
            visualScale = visual.localScale;
    }

    void Update()
    {
        HandleInput();
        CheckGround();
        UpdateTimers();
        HandleJump();
        BetterJumpPhysics();
        UpdateAnimator();
        HandleFlip();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    void HandleInput()
    {
        moveInput = 0f;

        if (Input.GetKey(KeyCode.A))
            moveInput = -1f;

        if (Input.GetKey(KeyCode.D))
            moveInput = 1f;

        if (Input.GetKeyDown(KeyCode.W))
            jumpBufferCounter = jumpBufferTime;
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );
    }

    void UpdateTimers()
    {
        if (isGrounded)
            coyoteTimeCounter = coyoteTime;
        else
            coyoteTimeCounter -= Time.deltaTime;

        jumpBufferCounter -= Time.deltaTime;
    }

    void HandleJump()
    {
        if (jumpBufferCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            jumpBufferCounter = 0f;
            coyoteTimeCounter = 0f;
        }
    }

    void ApplyMovement()
    {
        float control = isGrounded ? 1f : airControlMultiplier;
        rb.linearVelocity = new Vector2(moveInput * moveSpeed * control, rb.linearVelocity.y);
    }

    void BetterJumpPhysics()
    {
        if (rb.linearVelocity.y < 0f)
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallGravityMultiplier - 1f) * Time.deltaTime;
        }
        else if (rb.linearVelocity.y > 0f && !Input.GetKey(KeyCode.W))
        {
            rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpGravityMultiplier - 1f) * Time.deltaTime;
        }
    }

    void UpdateAnimator()
    {
        if (animator == null) return;

        animator.SetFloat("Speed", Mathf.Abs(moveInput));
        animator.SetBool("IsGrounded", isGrounded);
        animator.SetFloat("VerticalVelocity", rb.linearVelocity.y);
    }

    void HandleFlip()
    {
        if (visual == null) return;

        if (moveInput > 0.01f)
        {
            visual.localScale = new Vector3(Mathf.Abs(visualScale.x), visualScale.y, visualScale.z);
        }
        else if (moveInput < -0.01f)
        {
            visual.localScale = new Vector3(-Mathf.Abs(visualScale.x), visualScale.y, visualScale.z);
        }
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}