using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Move Settings")]
    [SerializeField] private float speed;
    [SerializeField] private ParticleSystem dust;

    [Header("Jump Settings")]
    [SerializeField] private float jumpingPower;
    [SerializeField] private float coyoteTime = 0.2f;
    [SerializeField] private float jumpBufferTime = 0.2f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [Header("Dash Settings")]
    [SerializeField] private float dashingPower;
    [SerializeField] private float dashingTime = 0.2f;

    private float jumpBufferTimeCounter;

    private float coyoteTimeCounter;

    private bool canDash = true;
    public bool isDashing { private set; get; }
    private const float dashingCoolDown = 1f;

    private bool isFacingRight = true;
    private float horizontal;

    private Animator am;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        am = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferTimeCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferTimeCounter -= Time.deltaTime;
        }

        if (jumpBufferTimeCounter > 0f && coyoteTimeCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            CreateDust();
            jumpBufferTimeCounter = 0f;
        }

        if (rb.velocity.y < 0f)
        {
            rb.velocity += 1.5f * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }
        else if (rb.velocity.y > 0f && !Input.GetButton("Jump"))
        {
            rb.velocity += 1f * Physics2D.gravity.y * Time.deltaTime * Vector2.up;
        }

        if (rb.velocity.y > 0f)
        {
            am.SetBool("IsFalling", false);
            am.SetBool("IsJumping", true);
        }
        else if (rb.velocity.y < -2f)
        {
            am.SetBool("IsFalling", true);
            am.SetBool("IsJumping", false);
        }
        else
        {
            am.SetBool("IsFalling", false);
            am.SetBool("IsJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) & canDash)
        {
            CreateDust();
            StartCoroutine(Dash());
        }

        Flip();
    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        am.SetFloat("Speed", Mathf.Abs(horizontal));
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.02f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
            CreateDust();
        }
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCoolDown);
        canDash = true;
    }

    private void CreateDust()
    {
        dust.Play();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, 0.02f);
    }
}